using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;
using TestingTask.Core.Services;

namespace TestingTask.Core.Test.UnitTests
{
    [TestClass]
    public class GroupValidatorUnitTest
    {
        [TestMethod]
        public void GroupValidator_ValidGroupWithPets_ReturnTrue()
        {
            var validator = new GroupValidator();

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

            Assert.IsTrue(validator.Validate(group));
        }

        [TestMethod]
        public void GroupValidator_ValidGroupWithOutPets_ReturnTrue()
        {
            var validator = new GroupValidator();

            Group group = new Group()
            {
                HasPets = false,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.IsTrue(validator.Validate(group));
        }

        [TestMethod]
        public void GroupValidator_OnlyChildrenGroupWithPets_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }

        [TestMethod]
        public void GroupValidator_EmptyGroup_ReturnFalse()
        {
            var validator = new GroupValidator();

            Group group = new Group()
            {
                Guests = new List<Guest>(),
                HasPets = false
            };

            Assert.IsFalse(validator.Validate(group));
        }

        [TestMethod]
        public void GroupValidator_GroupWithOutNames_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }

        [TestMethod]
        public void GroupValidator_OneGuestFromGroupWithOutFullName_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }

        [TestMethod]
        public void GroupValidator_OneGuestFromGroupWithOutFirstName_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }

        [TestMethod]
        public void GroupValidator_OneGuestFromGroupWithOutLastName_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }

        public void GroupValidator_OneGuestFromGroupWithVeryHighAge_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }

        //Regex.Match(firstNameTextBox.Text, "^[A-Z][a-zA-Z]*$")
        public void GroupValidator_OneGuestFromGroupWithInvalidFirstName_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }

        public void GroupValidator_OneGuestFromGroupWithInvalidLastName_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }

        public void GroupValidator_OneGuestFromGroupWithNegativeNumbersOfAge_ReturnFalse()
        {
            var validator = new GroupValidator();

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

            Assert.IsFalse(validator.Validate(group));
        }
    }
}
