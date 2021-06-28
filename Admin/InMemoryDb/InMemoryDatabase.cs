using System;
using System.Collections.Generic;
using Admin.Entities;
using System.Linq;
using Admin.Dtos;

namespace Admin.InMemoryDb
{
    public  class InMemoryDatabase{

        public List<User> users = new() //c#9 feature - target type new expression
        {
            new User{ Id = Guid.NewGuid(), FirstName="Jhon", LastName ="Wade" , UserName="jhon.wade", Password="P@1123", Email = "jhon.wade@test.com", Age = 30, CreatedDate = DateTimeOffset.Now},
            new User{ Id = Guid.NewGuid(), FirstName="Jame", LastName ="Russ" , UserName="jame.russ", Password="Q@1123", Email = "jame.russ@test.com", Age = 27, CreatedDate = DateTimeOffset.Now},
            new User{ Id = Guid.NewGuid(), FirstName="June", LastName ="Oliver" , UserName="june.oliver", Password="R@1123", Email = "june.oliver@test.com", Age = 33, CreatedDate = DateTimeOffset.Now},
            new User{ Id = Guid.NewGuid(), FirstName="Ammy", LastName ="Lime" , UserName="ammy.lime", Password="S@1123", Email = "ammy.lime@test.com", Age = 28, CreatedDate = DateTimeOffset.Now},
            new User{ Id = Guid.NewGuid(), FirstName="Ani", LastName ="Bill" , UserName="ani.Bill", Password="T@1123", Email = "ani.Bill@test.com", Age = 31, CreatedDate = DateTimeOffset.Now}
        };

    }
}