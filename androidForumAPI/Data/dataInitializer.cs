using androidForumAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Data
{
    public class DataInitializer
    {
        private readonly PostContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(PostContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {

                Customer customer = new Customer { UserName = "Adam101", Email = "adam101@hogent.be", FirstName = "Adam", LastName = "Master" };
                _dbContext.Customers.Add(customer);
                await CreateUser(customer.UserName, customer.Email, "P@ssword1111");
                Customer student = new Customer { UserName="student", Email = "student@hogent.be", FirstName = "Student", LastName = "Hogent" };
                _dbContext.Customers.Add(student);
                await CreateUser(student.UserName, student.Email, "P@ssword1111");
                _dbContext.SaveChanges();

                Post p1 = new Post { PostTitle = "vergadering", PostDescription = "De volgende vergadering van de lan zal doorgaan op 31/08/2019", DateAdded = new DateTime(2019, 8, 13), CreatorName = "Jan Janneman" };
                Post p2 = new Post { PostTitle = "pizza voor clubavond", PostDescription = "Wie gaat er mee pizza gaan eten voor de clubavond?", DateAdded = new DateTime(2019, 7, 18), CreatorName = "Peter Peterson" };
                Post p3 = new Post { PostTitle = "verslag", PostDescription = "Verslag van de vergadering van 12/08", DateAdded = new DateTime(2019, 8, 13), CreatorName = "Jan Janneman" };
                Post p4 = new Post { PostTitle = "feedback lan", PostDescription = "Wat vond je van de lan?? Laat  het ons weten via deze link", DateAdded = new DateTime(2019, 5, 5), CreatorName = "Dirk Dirkson" };
                Post p5 = new Post { PostTitle = "doop", PostDescription = "Voor alle schachten, nieuwe evenement, bowling! zie facebook voor meer informatie", DateAdded = new DateTime(2019, 8, 15), CreatorName = "Dirk Dirkson" };
                Post p6 = new Post { PostTitle = "verkiezingen", PostDescription = "Op 14 mei zullen er verkiezingen zijn voor het praesidium, meer informatie volgt", DateAdded = new DateTime(2019, 4, 18), CreatorName = "Jan Janneman" };
                Post p7 = new Post { PostTitle = "kandidaat stellen", PostDescription = "Wie zich kandidaat wenst te stellen moet een mail sturen naar admin@hogent.be", DateAdded = new DateTime(2019, 5, 1), CreatorName = "Dirk Dirkson" };
                Post p8 = new Post { PostTitle = "iemand een fietspomp die ik kan lenen", PostDescription = "help", DateAdded = new DateTime(2019, 7, 18), CreatorName = "Jan Janneman" };

                Reaction r1 = new Reaction() { ReactionDescription = "waar zal de vergadering zijn", DateAdded = new DateTime(2019, 8, 15, 8, 15, 59, 0), CreatorName = "Adam101" };
                Reaction r2 = new Reaction() { ReactionDescription = "Dat moet nog bevestigd worden", DateAdded = new DateTime(2019, 8, 15, 16, 4, 8, 0), CreatorName = "student101" };
                Reaction r3 = new Reaction { ReactionDescription = "Altijd zin in pizza", DateAdded = new DateTime(2019, 7, 18, 20, 22, 18, 0), CreatorName = "student101" };

                p1.AddReaction(r1);
                p1.AddReaction(r2);
                p1.AddReaction(r3);

                _dbContext.Add(p1);
                _dbContext.Add(p2);
                _dbContext.Add(p3);
                _dbContext.Add(p4);
                _dbContext.Add(p5);
                _dbContext.Add(p6);
                _dbContext.Add(p7);
                _dbContext.Add(p8);

                _dbContext.SaveChanges();
            }

          
        }
        private async Task CreateUser(string userName, string email, string password)
        {
            var user = new IdentityUser { UserName = userName, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
