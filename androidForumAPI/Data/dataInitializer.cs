using androidForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Data
{
    public class DataInitializer
    {
        private readonly PostContext _dbContext;

        public DataInitializer(PostContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Post p1 = new Post { PostTitle = "vergadering", PostDescription = "De volgende vergadering van de lan zal doorgaan op 31/08/2019", DateAdded = new DateTime(2019, 8, 13), CreatorName = "Jan Janneman" };
                Post p2 = new Post { PostTitle = "pizza voor clubavond", PostDescription = "Wie gaat er mee pizza gaan eten voor de clubavond?", DateAdded = new DateTime(2019, 7, 18), CreatorName = "Peter Peterson" };
                Post p3 = new Post { PostTitle = "verslag", PostDescription = "Verslag van de vergadering van 12/08", DateAdded = new DateTime(2019, 8, 13), CreatorName = "Jan Janneman" };
                Post p4 = new Post { PostTitle = "feedback lan", PostDescription = "Wat vond je van de lan?? Laat  het ons weten via deze link", DateAdded = new DateTime(2019, 5, 5), CreatorName = "Dirk Dirkson" };
                Post p5 = new Post { PostTitle = "doop", PostDescription = "Voor alle schachten, nieuwe evenement, bowling! zie facebook voor meer informatie", DateAdded = new DateTime(2019, 8, 15), CreatorName = "Dirk Dirkson" };
                Post p6 = new Post { PostTitle = "verkiezingen", PostDescription = "Op 14 mei zullen er verkiezingen zijn voor het praesidium, meer informatie volgt", DateAdded = new DateTime(2019, 4, 18), CreatorName = "Jan Janneman" };
                Post p7 = new Post { PostTitle = "kandidaat stellen", PostDescription = "Wie zich kandidaat wenst te stellen moet een mail sturen naar admin@hogent.be", DateAdded = new DateTime(2019, 5, 1), CreatorName = "Dirk Dirkson" };
                Post p8 = new Post { PostTitle = "iemand een fietspomp die ik kan lenen", PostDescription = "help", DateAdded = new DateTime(2019, 7, 18), CreatorName = "Jan Janneman" };

                _dbContext.SaveChanges();
            }
        }
    }
}
