using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using PhoneBook.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class PhoneBookController : Controller
    {
        private IRecordService recordService;
        private IAutoMapperService autoMapperService;
        private IOperationResult operationResult;
        private IStatusService statusService;
        private IAuthorizedUser authorizedUser;

        public PhoneBookController(IRecordService recordService,
            IAutoMapperService autoMapperService,
            IOperationResult operationResult,
            IStatusService statusService,
            IAuthorizedUser authorizedUser)
        {
            this.recordService = recordService;
            this.autoMapperService = autoMapperService;
            this.operationResult = operationResult;
            this.statusService = statusService;
            this.authorizedUser = authorizedUser;
        }

        // GET: PhoneBookController
        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            const int pageSize = 10;

            if (id < 1)
            {
                id = 1;
            }

            int recordsCount = this.recordService.GetCountOfRecords();
            var pager = new PageInfo(recordsCount, id, pageSize);
            int recordsSkip = (id - 1) * pageSize;

            var recordsFromDbForOnePage = this.recordService.GetRecordsForOnePage(recordsSkip, pager.PageSize);

            List<RecordViewModel> recordVM = this.autoMapperService
                .CreateListMapFromDomainToVMWithIncludeType<Record, RecordViewModel, User, UserViewModel, Status, StatusViewModel>(recordsFromDbForOnePage);
            this.ViewBag.AuthorizedUserId = this.authorizedUser.User.Id;
            this.ViewBag.Pager = pager;

            return View(recordVM);
        }

        // GET: PhoneBookController/Create
        public ActionResult Create()
        {
            ViewBag.Statuses = this.statusService.GetAllStatuses().Select(x => x.RecordStatus).ToList();
            return View();
        }

        // POST: PhoneBookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecordViewModel record)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Record recordDomain = this.autoMapperService
                        .CreateMapFromVMToDomain<RecordViewModel, Record>(record);
                    recordDomain.Status = this.statusService.GetStatusByName(record.RecordStatus);
                    recordDomain.DateAdded = DateTime.Now;
                    this.recordService.CreateRecord(recordDomain);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBookController/Edit/5
        public ActionResult Edit(Guid id)
        {
            RecordViewModel recordViewModel = this.autoMapperService.CreateMapFromVMToDomainWithIncludeLsitType
                <Record, RecordViewModel, Status, StatusViewModel>(this.recordService.GetRecord(id));

            return View(recordViewModel);
        }

        // POST: PhoneBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, RecordViewModel recordView)
        {
            try
            {
                Record recordToUpdate = this.autoMapperService.CreateMapFromVMToDomainWithIncludeLsitType
                    <RecordViewModel, Record, StatusViewModel, Status>(recordView);

                recordToUpdate.LastChangeDate = DateTime.Now;
                this.operationResult = this.recordService.UpdateRecord(recordToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBookController/Delete/5
        public ActionResult Delete(Guid id)
        {
            RecordViewModel recordViewModel = this.autoMapperService.CreateMapFromVMToDomainWithIncludeLsitType
                <Record, RecordViewModel, Status, StatusViewModel>(this.recordService.GetRecord(id));

            return View(recordViewModel);
        }

        // POST: PhoneBookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, RecordViewModel recordViewModel)
        {
            try
            {
                this.operationResult = this.recordService.DeleteRecord(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
