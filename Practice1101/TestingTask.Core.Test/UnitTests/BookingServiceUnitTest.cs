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
            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
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
        public void Book_GroupWithEmptyNames_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
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
        public void Book_OneGuestFromGroupWithEmptyFullName_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
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
        public void Book_OneGuestFromGroupEmptyFirstName_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
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
        public void Book_OneGuestFromGroupEmptyLastName_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 101, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        public void Book_OneGuestFromGroupWithAge100_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 100, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            var expectedRooms = new List<Room>() {
                        new Room() { Capacity = 3},
                        new Room() { Capacity = 2}
                    };
            List<Room> suitableRoomsResult = bookingService.Book(name, group);

            CollectionAssert.AreEqual(expectedRooms, suitableRoomsResult);
        }

        public void Book_OneGuestFromGroupWithAge0_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = 0, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            var expectedRooms = new List<Room>() {
                        new Room() { Capacity = 3},
                        new Room() { Capacity = 2}
                    };
            List<Room> suitableRoomsResult = bookingService.Book(name, group);

            CollectionAssert.AreEqual(expectedRooms, suitableRoomsResult);
        }

        [TestMethod]
        public void Book_OneGuestFromGroupWithNegativeNumbersOfAge_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
            Group group = new Group()
            {
                HasPets = true,
                Guests = new List<Guest>()
                {
                    new Guest() { Age = -1, FirstName = "John", LastName = "Lehnon" },
                    new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                    new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
                }
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_GroupIsNull_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
            Group group = null;

            Assert.ThrowsException<ArgumentException>(() => bookingService.Book(name, group));
        }

        [TestMethod]
        public void Book_GroupWithZeroCountOfGuests_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
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
            this.hotelsList.Add(
                new Hotel()
                {
                    Name = "test",
                    AllowPets = false,
                    Rooms =
                    {
                        new Room() { Capacity = 3},
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
                            new Room() { Capacity = 1},
                        }
                });

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            string name = "test";
            Group group = new Group();

            List<Guest> guests = new List<Guest>()
            {
                new Guest() { Age = 32, FirstName = "John", LastName = "Lehnon" },
                new Guest() { Age = 29, FirstName = "Yoko", LastName = "Ono" },
                new Guest() { Age = 4, FirstName = "Sean", LastName = "Lehnon" }
            };

            var expectedRooms = new List<Room> {
                        new Room() { Capacity = 3},
                        new Room() { Capacity = 2}
                    };
            List<Room> suitableRoomsResult = bookingService.Book(name, group);

            CollectionAssert.AreEqual(expectedRooms, suitableRoomsResult);
        }

        //GetSuitableNames
        [TestMethod]
        public void GetSuitableHotelNames_ValidGroupWithPets_ReturnListWithHotelNames()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

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

            var expectedNames = new List<string> { "test", "test1" };
            List<string> suitableHotelNamesResult = bookingService.GetSuitableHotelNames(group);

            CollectionAssert.AreEqual(expectedNames, suitableHotelNamesResult);
        }

        [TestMethod]
        public void GetSuitableHotelNames_NullGroup_TrowArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            Group group = null;

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_EmptyGroup_ArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

            Group group = new Group()
            {
                HasPets = false,
                Guests = new List<Guest>()
            };

            Assert.ThrowsException<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }

        [TestMethod]
        public void GetSuitableHotelNames_OneGuestFromGroupWithEmptyLastName_ArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

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
        public void GetSuitableHotelNames_OneGuestFromGroupWithEmtyFirstName_ArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

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
        public void GetSuitableHotelNames_OneGuestFromGroupWithEmptyFullName_ArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

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
        public void GetSuitableHotelNames_GroupEmptyAllNames_ArgumentException()
        {
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

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, hotelRepository.Object);

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
