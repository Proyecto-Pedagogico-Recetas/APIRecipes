using API.Services;
using Entities.Entities;

namespace TestProject.SampleData
{

    public class UserSampleData
    {
        public static IEnumerable<ValidatedUserItem> ValidUsersData{
            get
            {
                return new ValidatedUserItem[]
                {
                    new ValidatedUserItem {
                        Id = 1,
                        IdRol = 2,
                        UserName = "juanlu",
                        UserEmail = "juanlu@example.com",
                        UserPhone = 1234,
                        InsertDate = DateTime.Now.AddDays(-1),
                        IsActive = true,
                        EncryptedPassword = "mypassword",
                        EncryptedToken = "",
                        TokenExpireDate = DateTime.MinValue,
                        Password = "mypassword"
                    },
                    new ValidatedUserItem {
                        Id = 2,
                        IdRol = 3,
                        UserName = "anyi",
                        UserEmail = "anyi@example.com",
                        UserPhone = 5678,
                        InsertDate = DateTime.Now.AddDays(-2),
                        IsActive = true,
                        EncryptedPassword = "mysecretpassword",
                        EncryptedToken = "",
                        TokenExpireDate = DateTime.MinValue,
                        Password = "mysecretpassword"
                    },
                    new ValidatedUserItem {
                        Id = 3,
                        IdRol = 2,
                        UserName = "celia",
                        UserEmail = "celia@example.com",
                        UserPhone = 12345,
                        InsertDate = DateTime.Now.AddDays(-3),
                        IsActive = false,
                        EncryptedPassword = "supersecurepassword",
                        EncryptedToken = "",
                        TokenExpireDate = DateTime.MinValue,
                        Password = "supersecurepassword"
                    }
                };
            }
        }
        public static IEnumerable<ValidatedUserItem> InvalidUsersData
        {
            get
            {
                return new ValidatedUserItem[]
                {
                    new ValidatedUserItem {
                        Id = 1,
                        IdRol = 2,
                        UserName = "",
                        UserEmail = "invalidemail",
                        UserPhone = 1234,
                        InsertDate = DateTime.Now.AddDays(-1),
                        IsActive = true,
                        EncryptedPassword = "mypassword",
                        EncryptedToken = "",
                        TokenExpireDate = DateTime.MinValue,
                        Password = "mypassword"
                    },
                    new ValidatedUserItem {
                        Id = 2,
                        IdRol = 3,
                        UserName = "janedoe",
                        UserEmail = "",
                        UserPhone = 5678,
                        InsertDate = DateTime.Now.AddDays(-2),
                        IsActive = true,
                        EncryptedPassword = "mysecretpassword",
                        EncryptedToken = "",
                        TokenExpireDate = DateTime.MinValue,
                        Password = "mysecretpassword"
                    },
                    new ValidatedUserItem {
                        Id = 3,
                        IdRol = 2,
                        UserName = "bobsmith",
                        UserEmail = "bobsmith@example.com",
                        UserPhone = 12345,
                        InsertDate = DateTime.Now.AddDays(-3),
                        IsActive = false,
                        EncryptedPassword = "supersecurepassword",
                        EncryptedToken = "",
                        TokenExpireDate = DateTime.MinValue,
                        Password = "supersecurepassword"
                    }
                };
            }
        }
    }

    public class ValidatedUserItem : UserItem
        {
            public bool IsValid { get; set; }
    }

}

