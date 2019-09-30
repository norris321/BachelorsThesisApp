using Autofac.Extras.Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WcfService;
using Moq;
using WcfService.Logic;
using WcfService.Utilities;
using WcfService.DataContracts;

namespace WcfServiceTests
{

    [TestFixture]
    class LoginTest
    {
        [Test]
        public void Login_IsValid()
        {
            //arrrange
            var sampleUser = TestData.SampleUserData(1);
            Mock<IDataAccess> mock = new Mock<IDataAccess>();
            mock.Setup(x => x.ReadData_User(It.IsAny<string>(), It.IsAny<string>())).Returns(sampleUser[0]);
            MusicProcessor cls = new MusicProcessor(mock.Object);

            //act
            var actual = cls.Login(sampleUser[0].Username, sampleUser[0].Password);
            var expected = sampleUser[0];

            //Assert
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Rank, actual.Rank);
            Assert.AreEqual(expected.IdUser, actual.IdUser);
        }
        
    }

    [TestFixture]
    class GetAlbumTests
    {
        [Test]
        public void GetAlbum_IsValid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //arrange
                var sampleAlbum = TestData.SampleAlbumData(1);
                mock.Mock<IDataAccess>()
                    .Setup(x => x.ReadData_Album(1))
                    .Returns(sampleAlbum[0]);

                var cls = mock.Create<MusicProcessor>();

                //act
                var expected = sampleAlbum[0];
                var actual = cls.GetAlbum(1);

                //Assert
                Assert.AreEqual(expected.ArtistName, actual.ArtistName);
                Assert.AreEqual(expected.IdAlbum, actual.IdAlbum);
                Assert.AreEqual(expected.AlbumName, actual.AlbumName);

            }
        }
        //[Test]
        //[ExpectedException("System.NullReferenceException")]
        /*[ExpectedException]
        public void GetAlbum_NoDatabaseConnection()
        {
            MusicProcessor cls = new MusicProcessor(null);
            var actual = cls.GetAlbum(1);
            Assert.Throws<System>(() => new Customer(default(int)));
            //Assert.
        }*/

    }

    [TestFixture]
    class GetUserTests
    {
        [Test]
        public void GetUser_IsValid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //arrange
                var sampleUser = TestData.SampleUserData(1);
                mock.Mock<IDataAccess>()
                    .Setup(x => x.ReadData_User(1))
                    .Returns(sampleUser[0]);

                var cls = mock.Create<MusicProcessor>();

                //act
                var expected = sampleUser[0];
                var actual = cls.GetUser(1);

                //Assert
                Assert.AreEqual(expected.Username, actual.Username);
                //Assert.AreEqual(expected.Password, actual.Password);
                Assert.AreEqual(expected.Rank, actual.Rank);

            }
        }
    }

    [TestFixture]
    class GetRatingTests
    {
        [Test]
        public void GetRating_IsValid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //arrange
                var sampleRating = TestData.SampleRatingData(1);
                mock.Mock<IDataAccess>()
                    .Setup(x => x.ReadData_Rating(1))
                    .Returns(sampleRating[0]);

                var cls = mock.Create<MusicProcessor>();

                //act
                var expected = sampleRating[0];
                var actual = cls.GetRating(1);

                //Assert
                Assert.AreEqual(expected.IdAlbum, actual.IdAlbum);
                Assert.AreEqual(expected.IdUser, actual.IdUser);
                Assert.AreEqual(expected.Rating1, actual.Rating1);
                Assert.AreEqual(expected.IdRating, actual.IdRating);

            }
        }
    }

    [TestFixture]
    class GetAlbumsTests
    {
        [Test]
        public void GetAlbums_IsValid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //arrange
                var sampleAlbums = TestData.SampleAlbumData(5);
                mock.Mock<IDataAccess>()
                    .Setup(x => x.ReadData_Albums())
                    .Returns(sampleAlbums.ToArray());

                var cls = mock.Create<MusicProcessor>();

                //act
                var expected = sampleAlbums;
                var actual = cls.GetAlbums();

                //Assert
                Assert.AreEqual(expected.Count, actual.Length);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].ArtistName, actual[i].ArtistName);
                    Assert.AreEqual(expected[i].IdAlbum, actual[i].IdAlbum);
                    Assert.AreEqual(expected[i].AlbumName, actual[i].AlbumName);
                }
            }
        }
    }

    [TestFixture]
    class GetUsersTests
    {
        [Test]
        public void GetUsers_IsValid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //arrange
                var sampleUsers = TestData.SampleUserData(5);
                mock.Mock<IDataAccess>()
                    .Setup(x => x.ReadData_Users())
                    .Returns(sampleUsers.ToArray());

                var cls = mock.Create<MusicProcessor>();

                //act
                var expected = sampleUsers;
                var actual = cls.GetUsers();

                //Assert
                Assert.AreEqual(expected.Count, actual.Length);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Username, actual[i].Username);
                    //Assert.AreEqual(expected[i].Password, actual[i].Password);
                    Assert.AreEqual(expected[i].Rank, actual[i].Rank);
                    Assert.AreEqual(expected[i].IdUser, actual[i].IdUser);
                }
            }
        }
    }

    [TestFixture]
    class GetRatingsTests
    {

        [Test]
        public void GetRatings_IsValid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //arrange
                var sampleUsers = TestData.SampleRatingData(5);
                mock.Mock<IDataAccess>()
                    .Setup(x => x.ReadData_Ratings())
                    .Returns(sampleUsers.ToArray());

                var cls = mock.Create<MusicProcessor>();

                //act
                var expected = sampleUsers;
                var actual = cls.GetRatings();

                //Assert
                Assert.AreEqual(expected.Count, actual.Length);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].IdUser, actual[i].IdUser);
                    Assert.AreEqual(expected[i].IdRating, actual[i].IdRating);
                    Assert.AreEqual(expected[i].IdAlbum, actual[i].IdAlbum);
                    Assert.AreEqual(expected[i].Rating1, actual[i].Rating1);
                }
            }
        }
    }

    [TestFixture]
    class AddAlbumTests
    {

        [Test]
        public void AddAlbum_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var album = TestData.SampleAlbumData(1)[0];
                mock.Mock<IDataAccess>().Setup(x => x.SaveData_Album(album.ArtistName, album.AlbumName)).Returns(true);
                var cls = mock.Create<MusicProcessor>();
                //Act
                var actual = cls.AddAlbum(album.ArtistName, album.AlbumName);
                var expected = "Album added.";
                //Assert
                Assert.AreEqual(expected, actual);
                mock.Mock<IDataAccess>().Verify(x => x.SaveData_Album(album.ArtistName, album.AlbumName), Times.Exactly(1));
            }
        }

        [TestCase(1, "b", "a", ExpectedResult = "Artist and album name need to have between 3 and 30 characters.")]
        [TestCase(1, TestData.SampleString_Above30Characters, "abc", ExpectedResult = "Artist and album name need to have between 3 and 30 characters.")]
        [TestCase(1, "abc", TestData.SampleString_Above30Characters, ExpectedResult = "Artist and album name need to have between 3 and 30 characters.")]
        [TestCase(1, "", "aaa", ExpectedResult = "Input forms cannont be empty")]
        [TestCase(1, "bbb", "", ExpectedResult = "Input forms cannont be empty")]
        [TestCase(1, "", "", ExpectedResult = "Input forms cannont be empty")]
        //[TestCase(1, "dder", "cfgh", ExpectedResult = "Album added")]
        public string AddAlbumWrongInputs(int id, string artist, string album)
        {
            MusicServiceRest service = new MusicServiceRest();
            //Mock mock = new Mock<IDataAccess>().Setup(x => x.SaveData_User(It.IsAny<User>())).Returns(true);
            var testAlbum = new AlbumContract { IdAlbum = id, ArtistName = artist, AlbumName = album };
            string result = service.AddAlbum(testAlbum);

            return result;
        }

    }

    [TestFixture]
    class AddUserTests
    {
        [Test]
        public void AddUser_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var user = TestData.SampleUserData(1)[0];
                mock.Mock<IDataAccess>().Setup(x => x.SaveData_User(user)).Returns(true);
                var cls = mock.Create<MusicProcessor>();
                //Act
                var actual = cls.AddUser(user);
                var expected = "User added.";
                //Assert
                Assert.AreEqual(expected, actual);
                mock.Mock<IDataAccess>().Verify(x => x.SaveData_User(user), Times.Exactly(1));
            }
        }



        [TestCase(1, "", "aaa", ExpectedResult = "Input forms cannont be empty.")]
        [TestCase(1, "bbb", "", ExpectedResult = "Input forms cannont be empty.")]
        [TestCase(1, "d", "c", ExpectedResult = "User name needs to have between 3 and 30 characters.")]
        [TestCase(1, TestData.SampleString_Above30Characters, "abcd", ExpectedResult = "User name needs to have between 3 and 30 characters.")]
        [TestCase(1, "abc", "c", ExpectedResult = "Password needs to have between 3 and 30 characters.")]
        [TestCase(1, "abc", TestData.SampleString_Above30Characters, ExpectedResult = "Password needs to have between 3 and 30 characters.")]
        public string AddUser(int id, string username, string password)
        {
            MusicServiceRest service = new MusicServiceRest();

            UserLoginContract user = new UserLoginContract { Username = username, Password = password, Rank = "Admin" };

            string result = service.AddUser(user);

            return result;
        }
    }

    [TestFixture]
    class AddRatingTests
    {
        [Test]
        public void AddRating_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var rating = TestData.SampleRatingData(1)[0];
                mock.Mock<IDataAccess>().Setup(x => x.SaveData_Rating(It.IsAny<Rating>())).Returns(true);
                mock.Mock<IDataAccess>().Setup(x => x.ReadData_Album(It.IsAny<int>())).Returns(rating.Album);
                mock.Mock<IDataAccess>().Setup(x => x.ReadData_User(It.IsAny<int>())).Returns(rating.User);
                var cls = mock.Create<MusicProcessor>();
                //Act
                var actual = cls.AddRating(rating);
                var expected = "Rating added.";
                //Assert
                Assert.AreEqual(expected, actual);
                mock.Mock<IDataAccess>().Verify(x => x.SaveData_Rating(rating), Times.Exactly(1));
            }
        }

        [Test]
        public void AddRating_AlbumOrUserNotFoundInDB()
        {
            //Arrange
            Mock<IDataAccess> mock = new Mock<IDataAccess>();
            mock.Setup(x => x.ReadData_User(It.IsAny<int>())).Returns((User)null);
            mock.Setup(x => x.ReadData_Album(It.IsAny<int>())).Returns((Album)null);
            var cls = new MusicProcessor(mock.Object);
            //act
            Rating testRating = new Rating { IdAlbum = 1, IdUser = 1 };
            string actual = cls.AddRating(testRating);
            string expected = "Error: album or user record not found.";
            //
            mock.Verify(x => x.ReadData_User(It.IsAny<int>()), Times.Exactly(1));
            mock.Verify(x => x.ReadData_Album(It.IsAny<int>()), Times.Exactly(1));
            Assert.AreEqual(expected, actual);
        }
    }

    [TestFixture]
    class OverrideUserTests
    {

        [Test]
        public void OverrideUser_ValidCall()
        {
            //Arragnge
            var mock = new Mock<IDataAccess>();
            var user = TestData.SampleUserData(1)[0];
            mock.Setup(x => x.UpdateData_User(It.IsAny<User>())).Returns(true);
            var cls = new MusicProcessor(mock.Object);

            //Act
            var actual = cls.OverrideUser(user);

            //Assert
            mock.Setup(x => x.UpdateData_User(It.IsAny<User>())).Verifiable();
            Assert.AreEqual("User record was updated.", actual);
        }
    }

    [TestFixture]
    class OverrideAlbumTests
    {
        [Test]
        public void OverrideAlbum_ValidCall()
        {
            //Arragnge
            var mock = new Mock<IDataAccess>();
            var album = TestData.SampleAlbumData(1)[0];
            mock.Setup(x => x.UpdateData_Album(It.IsAny<Album>())).Returns(true);
            var cls = new MusicProcessor(mock.Object);

            //Act
            var actual = cls.OverrideAlbum(album);

            //Assert
            mock.Setup(x => x.UpdateData_Album(It.IsAny<Album>())).Verifiable();
            Assert.AreEqual("Album record was updated.", actual);
        }

    }

    [TestFixture]
    class OverrideRatingTests
    {

        [Test]
        public void OverrideRating_ValidCall()
        {
            //Arragnge
            var mock = new Mock<IDataAccess>();
            var rating = TestData.SampleRatingData(1)[0];
            mock.Setup(x => x.UpdateData_Rating(It.IsAny<int>(), It.IsAny<int?>())).Returns(true);
            var cls = new MusicProcessor(mock.Object);

            //Act
            var actual = cls.OverrideRating(It.IsAny<int>(), It.IsAny<int?>());

            //Assert
            mock.Setup(x => x.UpdateData_Rating(It.IsAny<Rating>())).Verifiable();
            Assert.AreEqual("Rating record was updated.", actual);
        }
    }

    

}
