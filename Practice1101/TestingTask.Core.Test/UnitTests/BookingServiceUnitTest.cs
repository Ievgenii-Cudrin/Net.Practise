using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;
using TestingTask.Core.Services;

namespace TestingTask.Core.Test.UnitTests
{
    [TestClass]
    public class BookingServiceUnitTest
    {
        private List<Hotel> hotelsList = new List<Hotel>();
        private Mock<IHotelRepository> hotelRepository;

        [TestInitialize]
        public void SetUp()
        {
            this.hotelRepository = new Mock<IHotelRepository>();
            this.hotelRepository.Setup(x => x.GetHotels()).Returns(() => this.hotelsList.AsQueryable());
        }

        [TestMethod]
        public void Book_NullString_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = null;
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_EmptyString_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = string.Empty;
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_OnlyChildrenGroupWithPets_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 3, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 2, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_GroupWithOutNames_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "", LastName = "" },
                    new Guest() { Age = 29, FirstName = "", LastName = "" },
                    new Guest() { Age = 41, FirstName = "", LastName = "" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_OneGuestFromGroupWithOutFullName_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "", LastName = "" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_OneGuestFromGroupWithOutFirstName_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_OneGuestFromGroupWithOutLastName_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_OneGuestFromGroupWithVeryHighAge_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 182, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_OneGuestFromGroupWithInvalidFirstName_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 182, FirstName = "Joh4@$35#5yr23n", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_OneGuestFromGroupWithInvalidLastName_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 182, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "O4@$35#5yr23no" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_OneGuestFromGroupWithNegativeNumbersOfAge_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = -32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_GroupIsNull_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = null;

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_GroupWithZeroCountOfGuests_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = string.Empty;
            Group group = new Group()
            {
                Guests = new List<Guest>(),
                HasPets = false
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_ValidGroupAndValidString_ReturnListRoom()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            string name = "name";
            Group group = new Group();

            List<Guest> guests = new List<Guest>()
            {
                new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
            };

            var expectedRooms = new List<Room>();
            List<Room> suitableRoomsResult = bookingService.Book(name, group);

            CollectionAssert.AreEqual(expectedRooms, suitableRoomsResult);
        }

        //GetSuitableNames
        [TestMethod]
        public void GetSuitableHotelNames_ValidGroupWithPets_ReturnListWithHotelNames()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            var expectedNames = new List<string>();
            List<string> suitableHotelNamesResult = bookingService.GetSuitableHotelNames(group);

            CollectionAssert.AreEqual(expectedNames, suitableHotelNamesResult);
        }

        [TestMethod]
        public void GetSuitableHotelNames_NullGroup_TrowArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = null;

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_EmptyGroup_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = false,
                Guests = new List<Guest>()
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithNegativeNumbersOfAge_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = -32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "O4@$35#5yr23no" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithInvalidLastName_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 182, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "O4@$35#5yr23no" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithInvalidFirstName_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 182, FirstName = "Joh4@$35#5yr23n", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithVeryHighAge_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 182, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithOutLastName_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithOutFirstName_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithOutFullName_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "", LastName = "" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_GroupWithOutNames_ArgumentException()
        {
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            Mock<IHotelRepository> hotelRepository = new Mock<IHotelRepository>();
            var bookingService = new BookingService(validator.Object, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "", LastName = "" },
                    new Guest() { Age = 29, FirstName = "", LastName = "" },
                    new Guest() { Age = 41, FirstName = "", LastName = "" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestCleanup]
        public void TearDown()
        {
            this.hotelsList.Clear();
        }
    }
}
