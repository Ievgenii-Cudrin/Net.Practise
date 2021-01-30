using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;
using System.Linq;
using TestingTask.Core.Services;

namespace TestingTask.Core.Test.UnitTests
{
    [TestClass]
    public class BookingServiceTests
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
        public void GetSuitableHotelNames_ValidGroupWithPets_ReturnsOneHotelNames()
        {
            // Arrange
            this.hotelsList.Add(new Hotel() { Name = "test", AllowPets = false });
            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);
            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 18, FirstName = "TestN", LastName = "TestF" }
                }
            };

            var expectedHotels = new List<Hotel>();

            //Act
            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(expectedHotels, hotelsResult);
        }

        //1 The whole group must be accommodated in one hotel
        //2 Room capacity shows the maximum number of adults + 1 child (up to 6 years old)
        [TestMethod]
        public void GetSuitableHotelNames_ValidGroupOneBigHotelOneLitleHotel_ReturnsOneHotelNames()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel() 
                { 
                    Name = "test", 
                    AllowPets = false, 
                    Rooms = 
                    {
                        new Room() { Capacity = 2},
                    } 
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 1},
                            new Room() { Capacity = 2}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 1, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 2, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 18, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" },
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(true);

            var expectedHotels = new List<string>();
            expectedHotels.Add("test");
            //Act
            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(expectedHotels, hotelsResult);
        }

        [TestMethod]
        public void GetSuitableHotelNames_ValidGroupTwoBigHotels_ReturnsTwoHotelNames()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 3},
                        new Room() { Capacity = 1}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 1},
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 1, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 2, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 18, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(true);

            var expectedHotels = new List<string>();
            expectedHotels.Add("test");
            expectedHotels.Add("test1");
            //Act
            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(expectedHotels, hotelsResult);
        }

        [TestMethod]
        public void GetSuitableHotelNames_ValidGroupTwoLitleHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 2}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 1}
                        }
                });
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 18, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(true);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }


        [TestMethod]
        public void GetSuitableHotelNames_NullGroupTwoLitleHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 4}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2}
                        }
                });
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            Group group = null;

            validator.Setup(x => x.Validate(group)).Returns(false);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_GroupWithOutGuestsTwoHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 4}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            Group group = new Group() { HasPets = false, Guests = new List<Guest>() };

            validator.Setup(x => x.Validate(group)).Returns(false);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithOutFirstNameTwoLitleHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 4},
                        new Room() { Capacity = 4}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 4}
                        }
                });
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 18, FirstName = "", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(false);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithOutSecondNameTwoLitleHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 4},
                        new Room() { Capacity = 4}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 4}
                        }
                });
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 18, FirstName = "TestN", LastName = "" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(false);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithNegativeAgeTwoLitleHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 4},
                        new Room() { Capacity = 4}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 4}
                        }
                });
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = -18, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(false);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithInvalidFirstNameTwoLitleHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 4},
                        new Room() { Capacity = 4}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 4}
                        }
                });
            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 18, FirstName = "Tes%4$3#@@^$%jhtN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(false);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithInvalidSecondNameTwoLitleHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 4},
                        new Room() { Capacity = 4}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 4}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 18, FirstName = "TestN", LastName = "Tes%4$3#@@^$%jhtF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(false);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithVeryHighAgeTwoLitleHotel_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add( 
                new Hotel() { Name = "test", AllowPets = false, Rooms =
                    {
                        new Room() { Capacity = 4},
                        new Room() { Capacity = 4}
                    }
                });
            this.hotelsList.Add(
                new Hotel() { Name = "test1", AllowPets = true, Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 4}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 1118, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(false);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        //3. Two child = one adult

        [TestMethod]
        public void GetSuitableHotelNames_FourChildTwoAdult_TwoHotelsNames()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 1},
                        new Room() { Capacity = 2}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 2}
                        }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test2",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 3},
                            new Room() { Capacity = 2}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 3, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 5, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 1, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(true);

            var expectedHotelsNames = new List<string>();
            expectedHotelsNames.Add("test1");
            expectedHotelsNames.Add("test2");

            //Act
            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(expectedHotelsNames, hotelsResult);
        }

        //4. A child cannot live in a room without adults

        public void GetSuitableHotelNames_SixChildTwoAdult_OneHotelsName()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 1},
                        new Room() { Capacity = 2}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 2}
                        }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test3",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 3},
                            new Room() { Capacity = 3}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 3, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 2, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 5, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 1, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(true);

            var expectedHotelsNames = new List<string>();
            expectedHotelsNames.Add("test3");

            //Act
            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(expectedHotelsNames, hotelsResult);
        }

        //5. The group may or may not have pets
        [TestMethod]
        public void GetSuitableHotelNames_GroupHasPetsTwoHotelsAllowPets_TwoHotelsName()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 1},
                        new Room() { Capacity = 2}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 2}
                        }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test3",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 3},
                            new Room() { Capacity = 3}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 3, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 2, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(true);

            var expectedHotelsNames = new List<string>();
            expectedHotelsNames.Add("test1");
            expectedHotelsNames.Add("test3");

            //Act
            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(expectedHotelsNames, hotelsResult);
        }

        [TestMethod]
        public void GetSuitableHotelNames_GroupHasNoPetsTwoHotelsAllowPets_ThreeHotelsName()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 1},
                        new Room() { Capacity = 2}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 2}
                        }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test3",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 3},
                            new Room() { Capacity = 3}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = false,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 3, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 2, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(true);

            var expectedHotelsNames = new List<string>();
            expectedHotelsNames.Add("test");
            expectedHotelsNames.Add("test1");
            expectedHotelsNames.Add("test3");

            //Act
            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(expectedHotelsNames, hotelsResult);
        }

        //6. The hotel may or may not allow pets
        [TestMethod]
        public void GetSuitableHotelNames_GroupHasPetsHotelNotAllowPets_ThrowArgumentException()
        {
            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 1},
                        new Room() { Capacity = 2}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = false,
                    Rooms =
                        {
                            new Room() { Capacity = 2},
                            new Room() { Capacity = 2}
                        }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test3",
                    AllowPets = false,
                    Rooms =
                        {
                            new Room() { Capacity = 3},
                            new Room() { Capacity = 3}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            var group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 3, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 2, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            validator.Setup(x => x.Validate(group)).Returns(true);

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        //8.One group can only have one reservation

        [TestMethod]
        public void Book_ValidGroupWithOneBook_OneBook()
        {
            var group = new Group()
            {
                HasPets = false,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 3, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 2, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 4, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 19, FirstName = "TestN", LastName = "TestF" },
                    new Guest() { Age = 28, FirstName = "TestN", LastName = "TestF" }
                }
            };

            // Arrange
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 1},
                        new Room() { Capacity = 2}
                    }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test1",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 2, BookedBy = group},
                            new Room() { Capacity = 2, BookedBy = group}
                        }
                });
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test3",
                    AllowPets = true,
                    Rooms =
                        {
                            new Room() { Capacity = 3},
                            new Room() { Capacity = 3}
                        }
                });

            Mock<IValidator<Group>> validator = new Mock<IValidator<Group>>();
            var bookingService = new BookingService(validator.Object, this.hotelRepository.Object);

            
            validator.Setup(x => x.Validate(group)).Returns(true);

            string name = "test";
            string secondName = "test1";
            string thirdName = "test3";

            //Act
            List<Room> bookedRoomsFirst = bookingService.Book(name, group);
            List<Room> bookedRoomsSecond = bookingService.Book(secondName, group);
            List<Room> bookedRoomsThird = bookingService.Book(thirdName, group);


            // Assert
            Assert.IsNull(bookedRoomsFirst);
            Assert.IsNotNull(bookedRoomsSecond);
            Assert.IsNull(bookedRoomsThird);
        }

        [TestCleanup]
        public void TearDown()
        {
            this.hotelsList.Clear();
        }
    }
}
