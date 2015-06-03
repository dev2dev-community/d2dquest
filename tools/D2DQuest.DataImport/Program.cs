using System;
using System.Collections.Generic;
using System.IO;
using D2DQuest.DataAccessLayer;
using D2DQuest.ObjectDomain;

namespace D2DQuest.DataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                var unique = new List<string>();
                using (var db = new D2DQuestDbContext("D2DQuest"))
                {
                    foreach (var line in File.ReadAllLines(args[0]))
                    {
                        var sp = line.Split(',');

                        if (String.IsNullOrWhiteSpace(sp[1]))
                            continue;

                        if (!unique.Contains(sp[1]))
                        {
                            db.Visiters.Add(new Visiter()
                            {
                                Name = sp[0].Trim(),
                                Uid = sp[1].Trim().ToUpper()
                            });
                            unique.Add(sp[1]);
                        }
                    }

                    unique = new List<string>();

                    foreach (var line in File.ReadAllLines(args[1]))
                    {
                        if (String.IsNullOrWhiteSpace(line))
                            continue;

                        if (!unique.Contains(line))
                        {
                            unique.Add(line);
                            db.Words.Add(new KeyWord() {Word = line.Trim().ToLower()});
                        }
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
    }
}
