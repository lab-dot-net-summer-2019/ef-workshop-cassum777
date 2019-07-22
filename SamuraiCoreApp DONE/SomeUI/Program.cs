using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            InsertSamurai();
            InsertMultipleSamurais();
            InsertMultipleSamuraisViaBatch();
            SimpleSamuraiQuery();
            MoreQueries();
            RetrieveAndUpdateSamurai();
            RetrieveAndUpdateMultipleSamurais();
            MultipleDatabaseOperations();
            QueryAndUpdateSamurai_Disconnected();
            InsertBattle();
            QueryAndUpdateBattle_Disconnected();
            AddSomeMoreSamurais();
            DeleteWhileTracked();
            DeleteMany();
            DeleteWhileNotTracked();
            DeleteUsingId(3);

            //______
            InsertNewPkFkGraph();
            InsertNewPkFkGraphMultipleChildren();
            AddChildToExistingObjectWhileTracked();
            AddChildToExistingObjectWhileNotTracked(2);
            EagerLoadSamuraiWithQuotes();
            var dynamicList = ProjectDynamic();
            ProjectSomeProperties();
            ProjectSamuraisWithQuotes();
            FilteringWithRelatedData();
            ModifyingRelatedDataWhenTracked();
            ModifyingRelatedDataWhenNotTracked();
        }

        private static void InsertMultipleSamuraisViaBatch()
        {
            //EF Core 2.1 added a minimum batch size which defaults to 4
            //this 4 object insert WILL be batched
            var samurai1 = new Samurai { Name = "Samurai1" };
            var samurai2 = new Samurai { Name = "Samurai2" };
            var samurai3 = new Samurai { Name = "Samurai3" };
            var samurai4 = new Samurai { Name = "Samurai4" };
            using (var context = new SamuraiContext()) {
                context.Samurai.AddRange(samurai1, samurai2, samurai3, samurai4);
                context.SaveChanges();
            }
        }

        private static void DeleteUsingId(int samuraiId)
        {
            var samurai = _context.Samurai.Find(samuraiId);
            _context.Remove(samurai);
            _context.SaveChanges();
            //alternate: call a stored procedure!
            //_context.Database.ExecuteSqlCommand("exec DeleteById {0}", samuraiId);
        }

        private static void AddSomeMoreSamurais()
        {
            _context.AddRange(
               new Samurai { Name = "Kambei Shimada" },
               new Samurai { Name = "Shichirōji " },
               new Samurai { Name = "Katsushirō Okamoto" },
               new Samurai { Name = "Heihachi Hayashida" },
               new Samurai { Name = "Kyūzō" },
               new Samurai { Name = "Gorōbei Katayama" }
             );
            _context.SaveChanges();
        }

        private static void DeleteWhileTracked()
        {
            var samurai = _context.Samurai.FirstOrDefault(s => s.Name == "Kambei Shimada");
            _context.Samurai.Remove(samurai);
            //alternates:
            // _context.Remove(samurai);
            // _context.Entry(samurai).State=EntityState.Deleted;
            // _context.Samurais.Remove(_context.Samurais.Find(1));
            _context.SaveChanges();
        }

        private static void DeleteMany()
        {
            var samurais = _context.Samurai.Where(s => s.Name.Contains("ō"));
            _context.Samurai.RemoveRange(samurais);
            //alternate: _context.RemoveRange(samurais);
            _context.SaveChanges();
        }

        private static void DeleteWhileNotTracked()
        {
            var samurai = _context.Samurai.FirstOrDefault(s => s.Name == "Heihachi Hayashida");
            using (var contextNewAppInstance = new SamuraiContext()) {
                contextNewAppInstance.Samurai.Remove(samurai);
                var t = contextNewAppInstance.Entry(samurai).State;//=EntityState.Deleted;
                contextNewAppInstance.SaveChanges();
            }
        }


        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Julie" };
            using (var context = new SamuraiContext()) {
                context.Samurai.Add(samurai);
                context.SaveChanges();
            }
        }
        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext()) {
                var samurais = context.Samurai.ToList();
                //var query = context.Samurais;
                //var samuraisAgain = query.ToList();
                foreach (var samurai in context.Samurai) {
                    Console.WriteLine(samurai.Name);
                }
            }
        }
        private static void MoreQueries()
        {
            var samurais_NonParameterizedQuery = _context.Samurai.Where(s => s.Name == "Sampson").ToList();
            var name = "Sampson";
            var samurais_ParameterizedQuery = _context.Samurai.Where(s => s.Name == name).ToList();
            var samurai_Object = _context.Samurai.FirstOrDefault(s => s.Name == name);
            var samurais_ObjectFindByKeyValue = _context.Samurai.Find(2);
            var lastSampson = _context.Samurai.OrderBy(s => s.Id).LastOrDefault(s => s.Name == name);
            var samuraisJ = _context.Samurai.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();

        }


        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurai.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }
        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurai.ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }
        private static void MultipleDatabaseOperations()
        {
            var samurai = _context.Samurai.FirstOrDefault();
            samurai.Name += "Hiro";
            _context.Samurai.Add(new Samurai { Name = "Kikuchiyo" });
            _context.SaveChanges();
        }


        private static void QueryAndUpdateSamurai_Disconnected()
        {
            var samurai = _context.Samurai.FirstOrDefault(s => s.Name == "Kikuchiyo");
            samurai.Name += "San";
            using (var newContextInstance = new SamuraiContext()) {
                newContextInstance.Samurai.Update(samurai);
                newContextInstance.SaveChanges();
            }
        }
        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Julie" };
            var samuraiSammy = new Samurai { Name = "Sampson" };
            using (var context = new SamuraiContext()) {
                context.Samurai.AddRange(samurai, samuraiSammy);
                context.SaveChanges();
            }
        }
        private static void InsertBattle()
        {
            _context.Battles.Add(new Battle {
                Name = "Battle of Okehazama",
                StartDate = new DateTime(1560, 05, 01),
                EndDate = new DateTime(1560, 06, 15)
            });
            _context.SaveChanges();
        }
        private static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = _context.Battles.FirstOrDefault();
            battle.EndDate = new DateTime(1560, 06, 30);
            using (var newContextInstance = new SamuraiContext()) {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }

        private static void ModifyingRelatedDataWhenTracked()
        {
            var samurai = _context.Samurai.Include(s => s.Quotes).FirstOrDefault();
            samurai.Quotes[0].Text += " Did you hear that?";
            _context.SaveChanges();
        }

        private static void ModifyingRelatedDataWhenNotTracked()
        {
            var samurai = _context.Samurai.Include(s => s.Quotes).FirstOrDefault();
            var quote = samurai.Quotes[0];
            quote.Text += " Did you hear that?";
            using (var newContext = new SamuraiContext()) {
                //newContext.Quotes.Update(quote);
                newContext.Entry(quote).State = EntityState.Modified;
                newContext.SaveChanges();
            }
        }


        private static void FilteringWithRelatedData()
        {
            var samurais = _context.Samurai
                                   .Where(s => s.Quotes.Any(q => q.Text.Contains("happy")))
                                   .ToList();
        }

        private static void ProjectSamuraisWithQuotes()
        {
            var somePropertiesWithQuotes = _context.Samurai
                .Select(s => new { s.Id, s.Name, s.Quotes.Count })
                .ToList();

        }

        public struct IdAndName
        {
            public IdAndName(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public int Id;
            public string Name;
        }
        private static void ProjectSomeProperties()
        {
            var someProperties = _context.Samurai.Select(s => new { s.Id, s.Name }).ToList();
            var idsAndNames = _context.Samurai.Select(s => new IdAndName(s.Id, s.Name)).ToList();
        }

        private static List<dynamic> ProjectDynamic()
        {
            var someProperties = _context.Samurai.Select(s => new { s.Id, s.Name }).ToList();
            return someProperties.ToList<dynamic>();
        }

        private static void EagerLoadSamuraiWithQuotes()
        {
            var samuraiWithQuotes = _context.Samurai.Where(s => s.Name.Contains("Kyūzō"))
                                                     .Include(s => s.Quotes)
                                                     .Include(s => s.SecretIdentity)
                                                     .FirstOrDefault();
        }

        private static void AddChildToExistingObjectWhileNotTracked(int samuraiId)
        {
            var quote = new Quote {
                Text = "Now that I saved you, will you feed me dinner?",
                SamuraiId = samuraiId
            };
            using (var newContext = new SamuraiContext()) {
                newContext.Quotes.Add(quote);
                newContext.SaveChanges();
            }
        }

        private static void AddChildToExistingObjectWhileNotTracked_Error(int samuraiId)
        {
            try
            {
                var samurai = _context.Samurai.First();

                using (var newContext = new SamuraiContext()) {
                    var quote = new Quote {
                        Text = "Now that I saved you, will you feed me dinner?"
                    };
                    samurai.Quotes.Add(quote);
                    newContext.Samurai.Add(samurai);
                    newContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                
            }
            
        }

        private static void AddChildToExistingObjectWhileTracked()
        {
            var samurai = _context.Samurai.First();
            samurai.Quotes.Add(new Quote {
                Text = "I bet you're happy that I've saved you!"
            });
            _context.SaveChanges();
        }

        private static void InsertNewPkFkGraphMultipleChildren()
        {
            var samurai = new Samurai {
                Name = "Kyūzō",
                Quotes = new List<Quote> {
                  new Quote {Text = "Watch out for my sharp sword!"},
                  new Quote {Text="I told you to watch out for the sharp sword! Oh well!" }
                }
            };
            _context.Samurai.Add(samurai);
            _context.SaveChanges();
        }

        private static void InsertNewPkFkGraph()
        {
            var samurai = new Samurai {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>
                               {
                                 new Quote {Text = "I've come to save you"}
                               }
            };
            _context.Samurai.Add(samurai);
            _context.SaveChanges();
        }
    }
}
