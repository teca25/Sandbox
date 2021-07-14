using System;
using System.Collections.Generic;
using System.Data;

namespace sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnect dbConnect = new DBConnect();
            Users currentUser = new Users("","","",DateTime.Now);
        Start:
            Console.WriteLine("Za login stisnete 1 ili za register 2");
            var input = Console.ReadLine();



            bool successfull = false;
            while (!successfull)
            {

                if (input == "1")
                {
                    Console.WriteLine("Write your username:");
                    var username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password = Console.ReadLine();

                    // string userrId=  dbConnect.Select($"select id from users where userName ='{username}' and UserPassword= '{password}' ");
                    //List<string> list = dbConnect.SelectUsers($"select * from users where userName ='{username}' and UserPassword= '{password}' ")[0];
                    DataSet user = dbConnect.SelectDataSet($"select * from users where userName ='{username}' and UserPassword= '{password}' ");
                    if (user.Tables[0].Rows.Count != 0)
                    {
                        successfull = true;
                        currentUser = new Users(user.Tables[0].Rows[0]["UserName"].ToString(), user.Tables[0].Rows[0]["UserPassword"].ToString(), user.Tables[0].Rows[0]["UserRole"].ToString(), DateTime.Parse(user.Tables[0].Rows[0]["DateCreated"].ToString()));
                        Console.WriteLine("You have seccessfully loged in!");
                        goto Login;
                    }
                    else
                    {
                        successfull = false;
                    }
                    if (!successfull)
                    {
                        Console.WriteLine("Your username or password is incorect, try again !!!");
                    }

                }

                else if (input == "2")
                {

                    Console.WriteLine("Enter your username:");
                    string username = Console.ReadLine();

                    Console.WriteLine("Enter your password:");
                    string password = Console.ReadLine();

                    Console.WriteLine("Enter your userRole:");
                    string userRole = Console.ReadLine();

                    DateTime now = DateTime.Now;
                    //Array.Resize(ref arrUsers, arrUsers.Length + 1);
                    //arrUsers[arrUsers.Length - 1] = new Users(username, password, userRole, now);
                    dbConnect.InsertUpdateDelete($"insert into users(userName,userPassword,userRole,dateCreated) values('{username}','{password}','{userRole}','{now.ToString("yyyy-MM-dd HH:mm:ss")}')");
                    successfull = true;
                    goto Start;

                }
                else
                {
                    Console.WriteLine("Try again !!!");
                    goto Start;
                }

            }

        Login:
            Console.WriteLine("Za redaktirane na potrebitelq 3 ");
            Console.WriteLine("Za syzdavene na geeroi 4");
            Console.WriteLine("Za spisyk na sichki geroi za potrebitelq 5");
            Console.WriteLine("Za dataili na geroi 6");
            Console.WriteLine("Za redaktirane na geroi 7");
            Console.WriteLine("Za iztrivane na geroi 8");
            Console.WriteLine("Za bitka 9");
            Console.WriteLine("Za logout 10");
            var vkarano = Console.ReadLine();

            if (vkarano == "3")
            {
                Console.WriteLine("username:");
                var username = Console.ReadLine();
                Console.WriteLine("password:");
                var password = Console.ReadLine();
                Console.WriteLine("userrole:");
                var userRole = Console.ReadLine();

                if (username != "" && password != "" && userRole != "")
                {
                    dbConnect.InsertUpdateDelete($"Update users set UserName='{username}',UserPassword='{password}',UserRole='{userRole}' where UserName = '{currentUser.username}' and DateCreated ='{currentUser.dateCreated.ToString("yyyy-MM-dd HH:mm:ss")}'");
                    Console.WriteLine("promqnata se zapazi!");
                    goto Login;
                }
                else if (username != "" && password != "")
                {
                    dbConnect.InsertUpdateDelete($"Update users set UserName='{username}',UserPassword='{password}', where UserName = '{currentUser.username}' and DateCreated ='{currentUser.dateCreated.ToString("yyyy-MM-dd HH:mm:ss")}'");
                    Console.WriteLine("promqnata se zapazi!");
                    goto Login;
                }
                else if(password != "" && userRole != "")
                {
                    dbConnect.InsertUpdateDelete($"Update users set UserPassword='{password}',UserRole='{userRole}' where UserName = '{currentUser.username}' and DateCreated ='{currentUser.dateCreated.ToString("yyyy-MM-dd HH:mm:ss")}'");
                    Console.WriteLine("promqnata se zapazi!");
                    goto Login;
                }
                else if(username != "" && userRole != "")
                {
                    dbConnect.InsertUpdateDelete($"Update users set UserName='{username}',UserRole='{userRole}' where UserName = '{currentUser.username}' and DateCreated ='{currentUser.dateCreated.ToString("yyyy-MM-dd HH:mm:ss")}'");
                    Console.WriteLine("promqnata se zapazi!");
                    goto Login;
                }
                else if(username != "")
                {
                    dbConnect.InsertUpdateDelete($"Update users set UserName='{username}' where UserName = '{currentUser.username}' and DateCreated ='{currentUser.dateCreated.ToString("yyyy-MM-dd HH:mm:ss")}'");
                    Console.WriteLine("promqnata se zapazi!");
                    goto Login;
                }
                else if (password != "")
                {
                    dbConnect.InsertUpdateDelete($"Update users set UserPassword = '{password}' where UserName = '{currentUser.username}' and DateCreated ='{currentUser.dateCreated.ToString("yyyy-MM-dd HH:mm:ss")}'");
                    Console.WriteLine("promqnata se zapazi!");
                    goto Login;
                }
                else if (userRole != "")
                {
                    dbConnect.InsertUpdateDelete($"Update users set UserRole = '{userRole}' where UserName = '{currentUser.username}' and DateCreated ='{currentUser.dateCreated.ToString("yyyy-MM-dd HH:mm:ss")}'");
                    Console.WriteLine("promqnata se zapazi!");
                    goto Login;
                }
                else
                {
                    Console.WriteLine("nishto ne e promeneno!");
                    goto Login;
                }
            }
            else if (vkarano == "4")
            {
                Console.WriteLine("enter character name:");
                var charactername = Console.ReadLine();
                Console.WriteLine("enter character type:");
                var charactertype = Console.ReadLine();
                Console.WriteLine("enter attack points:");
                var attackpoints = Console.ReadLine();
                Console.WriteLine("enter defence points:");
                var defencepoints = Console.ReadLine();
                Console.WriteLine("enter health points:");
                var healthpoints = Console.ReadLine();

                if (charactername != "" && charactertype != "" && attackpoints != "" && defencepoints != "" && healthpoints != "" )
                {
                    string userId = dbConnect.Select($"select id from users where userName ='{currentUser.username}' and UserPassword= '{currentUser.password}' ");
                    dbConnect.InsertUpdateDelete($"insert into characters (Userid,CharacterName,CharacterType,AttackPoints,DefencePoints,HealthPoints,DateCreated) values ('{userId}','{charactername}','{charactertype}','{attackpoints}','{defencepoints}','{healthpoints}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");
                    Console.WriteLine("You have successfully created new character!");
                    goto Login;
                }
                else
                {
                    Console.WriteLine("ne sa vavedeni vsichki poleta opitaite pak!");
                    goto Login;
                }

            }
            else if (vkarano == "5" || vkarano == "6" || vkarano == "7" || vkarano == "8")
            {
                string userId = dbConnect.Select($"select id from users where userName ='{currentUser.username}' and UserPassword= '{currentUser.password}' ");
                DataSet characters = dbConnect.SelectDataSet($"select * from characters where Userid='{userId}'");
                var characterName = "";
                if (vkarano == "6" || vkarano == "7")
                {
                    Console.WriteLine("izberi geroi:");
                    characterName = Console.ReadLine();
                }
                    foreach (DataRow dr in characters.Tables[0].Rows)
                  {
                    if (vkarano == "6" && dr["CharacterName"].ToString() == characterName)
                    {
                        Console.WriteLine(string.Format("CharacterName:{0}", dr["CharacterName"].ToString()));
                        Console.WriteLine(string.Format("CharacterType:{0}", dr["CharacterType"].ToString()));
                        Console.WriteLine(string.Format("AttackPoints:{0}", dr["AttackPoints"].ToString()));
                        Console.WriteLine(string.Format("DefencePoints:{0}", dr["DefencePoints"].ToString()));
                        Console.WriteLine(string.Format("HealthPoints:{0}", dr["HealthPoints"].ToString()));
                        Console.WriteLine(string.Format("DateCreated:{0}", dr["DateCreated"].ToString()));
                        goto Login;
                    }
                    else if(vkarano == "5")
                    {
                        Console.WriteLine(string.Format("CharacterName:{0}", dr["CharacterName"].ToString()));
                        goto Login;
                    }
                    else if(vkarano == "7")
                    {
                        Console.WriteLine("CharacterName:");
                        var CharacterName = Console.ReadLine();
                        Console.WriteLine("CharacterType:");
                        var CharacterType = Console.ReadLine();
                        Console.WriteLine("AttackPoints:");
                        // int AttackPoints = int.Parse(Console.ReadLine());
                        var AttackPoints = Console.ReadLine();
                        Console.WriteLine("DefencePoints:");
                        // int DefencePoints = int.Parse(Console.ReadLine());
                        var DefencePoints = Console.ReadLine();
                        Console.WriteLine("HealthPoints:");
                        // int HealthPoints = int.Parse(Console.ReadLine());
                        var HealthPoints = Console.ReadLine();

                        if (CharacterName != "" && CharacterType != "" && AttackPoints != "" && DefencePoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',CharacterType='{CharacterType}',AttackPoints='{AttackPoints}',DefencePoints='{DefencePoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterName != "" && CharacterType != "" && AttackPoints != "" && DefencePoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',CharacterType='{CharacterType}',AttackPoints='{AttackPoints}',DefencePoints = '{DefencePoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterName != "" && CharacterType != "" && AttackPoints !="" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',CharacterType='{CharacterType}',AttackPoints='{AttackPoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterName !="" && CharacterType != ""&& DefencePoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',CharacterType='{CharacterType}',DefencePoints='{DefencePoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterName !="" && AttackPoints !="" && DefencePoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',AttackPoints='{AttackPoints}',DefencePoints='{DefencePoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterType != "" && AttackPoints !="" && DefencePoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterType='{CharacterType}',AttackPoints='{AttackPoints}',DefencePoints='{DefencePoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterName != "" && CharacterType != "" && AttackPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',CharacterType='{CharacterType}',AttackPoints='{AttackPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterName != "" && CharacterType != "" && DefencePoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',CharacterType='{CharacterType}',DefencePoints='{DefencePoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterName != "" && CharacterType != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',CharacterType='{CharacterType}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterName != "" && AttackPoints != "" && DefencePoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',AttackPoints='{AttackPoints}',DefencePoints='{DefencePoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterName != "" && AttackPoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',AttackPoints='{AttackPoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterName != "" && DefencePoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',DefencePoints='{DefencePoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterType != "" && AttackPoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterType='{CharacterType}',AttackPoints='{AttackPoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterType != "" && AttackPoints != "" && DefencePoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterType='{CharacterType}',AttackPoints='{AttackPoints}',DefencePoints = '{DefencePoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterType != "" && DefencePoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterType='{CharacterType}',DefencePoints='{DefencePoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterName != "" && CharacterType != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',CharacterType='{CharacterType}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterName !="" && AttackPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',AttackPoints='{AttackPoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterName != "" && DefencePoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}'DefencePoints='{DefencePoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterName != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterType != "" && AttackPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterType='{CharacterType}',AttackPoints='{AttackPoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterType != "" && DefencePoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterType='{CharacterType}',DefencePoints='{DefencePoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterType != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterType='{CharacterType}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if (AttackPoints != "" && DefencePoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set AttackPoints='{AttackPoints}',DefencePoints='{DefencePoints}' where CharacterName = '{characterName}'");
                        }
                        else if (AttackPoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set AttackPoints='{AttackPoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(DefencePoints != "" && HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set DefencePoints='{DefencePoints}',HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else if (CharacterName != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterName='{CharacterName}' where CharacterName = '{characterName}'");
                        }
                        else if(CharacterType != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set CharacterType='{CharacterType}' where CharacterName = '{characterName}'");
                        }
                        else if(AttackPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set AttackPoints='{AttackPoints}' where CharacterName = '{characterName}'");
                        }
                        else if(DefencePoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set DefencePoints='{DefencePoints}' where CharacterName = '{characterName}'");
                        }
                        else if(HealthPoints != "")
                        {
                            dbConnect.InsertUpdateDelete($"Update characters set HealthPoints='{HealthPoints}' where CharacterName = '{characterName}'");
                        }
                        else
                        {
                            Console.WriteLine("Geroqt ne e promenen!");
                            goto Login;
                        }
                    }
                    else if (vkarano == "8")
                    {
                        foreach(DataRow drr in characters.Tables[0].Rows)
                        {
                            Console.WriteLine(string.Format("CharacterName:{0}", drr["CharacterName"].ToString()));
                        }
                        Console.WriteLine("izberi koi geroi shte iztriesh:");
                        var cfd = Console.ReadLine();
                       dbConnect.InsertUpdateDelete($"Delete from characters where CharacterName = '{cfd}'");
                        goto Login;
                    }
                 }
                
            }
            else if(vkarano == "10")
            {
                currentUser = null;
                goto Start;
            }
            else if (vkarano == "9")
            {
                goto Fight;
            }
            else
            {
                Console.WriteLine("Try again !!!");
                goto Login;
            }
        Fight:
            
            Console.WriteLine("zapochni bitka 1");
            Console.WriteLine("spisyk na provedeni bitki 2");
            Console.WriteLine("detaili za bitka 3");
            var inn = Console.ReadLine();
            if (inn == "1")
            {
                Hero hero1 = null;
                Hero hero2 = null;
                string userId = dbConnect.Select($"select id from users where userName ='{currentUser.username}' and UserPassword= '{currentUser.password}' ");
                DataSet yourheros = dbConnect.SelectDataSet($"select * from characters where Userid='{userId}'");
                foreach (DataRow dr in yourheros.Tables[0].Rows)
                {
                    Console.WriteLine(string.Format("CharacterName:{0}", dr["CharacterName"].ToString()));
                }
                Console.WriteLine("izberi si geroi:");
                var thechosen = Console.ReadLine();
                foreach (DataRow dr in yourheros.Tables[0].Rows)
                {
                    //Console.WriteLine(string.Format("CharacterName:{0}", dr["CharacterName"].ToString()));
                    if (dr["CharacterName"].ToString() == thechosen)
                    {
                        hero1 = new Hero(Convert.ToInt32(dr["Id"]),Convert.ToInt32(dr["AttackPoints"]), Convert.ToInt32(dr["DefencePoints"]), Convert.ToInt32(dr["HealthPoints"]));
                    }
                }
                if (hero1 == null)
                {
                    Console.WriteLine("Nqma geroi s takova ime");
                    goto Fight;
                }
                DataSet anotherheroes = dbConnect.SelectDataSet($"Select * from characters where Userid !='{userId}'");
                foreach (DataRow dr in anotherheroes.Tables[0].Rows)
                {
                    Console.WriteLine(string.Format("CharacterName:{0}", dr["CharacterName"].ToString()));
                }
                /*foreach (DataRow dr in yourheros.Tables[0].Rows)
                {
                    //Console.WriteLine(string.Format("CharacterName:{0}", dr["CharacterName"].ToString()));
                    if (dr["CharacterName"].ToString() == thechosen)
                    {
                        hero1 = new Hero(Convert.ToInt32(dr["UserId"]),Convert.ToInt32(dr["AttackPoints"]), Convert.ToInt32(dr["DefencePoints"]), Convert.ToInt32(dr["HealthPoints"]));
                    }
                }*/
                Console.WriteLine("izberi uponent:");
                var uponent = Console.ReadLine();
                foreach (DataRow dr in anotherheroes.Tables[0].Rows)
                {
                    Console.WriteLine(string.Format("CharacterName:{0}", dr["CharacterName"].ToString()));
                    if (dr["CharacterName"].ToString() == uponent)
                    {
                        hero2 = new Hero(Convert.ToInt32(dr["Id"]),Convert.ToInt32(dr["AttackPoints"]), Convert.ToInt32(dr["DefencePoints"]), Convert.ToInt32(dr["HealthPoints"]));
                    }
                }
                if (hero2 == null)
                {
                    Console.WriteLine("Nqma geroi s takova ime!");
                    goto Fight;
                }
                int counter = 0;
                while (hero1.healthpoints > 0 || hero2.healthpoints > 0)
                {
                    if (counter != 0)
                    {
                        dbConnect.InsertUpdateDelete($"insert into battle_rounds(Character1State,Character2State,RoundIndex) values('{hero1.healthpoints}','{hero2.healthpoints}','{counter}')");

                    }
                    hero2.healthpoints = hero2.healthpoints - (hero1.attackpoints - hero2.defencepoints);
                    if (hero2.healthpoints <= 0)
                    {
                        Console.WriteLine("Ti si pobeditel");
                        dbConnect.InsertUpdateDelete($"Insert into battle_result(Userid,Winnerid,Loseid,CreatedDate)" +
                            $" values('{userId}','{hero1.id}','{hero2.id}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");
                        goto Fight;
                    }
                    hero1.healthpoints = hero1.healthpoints - (hero2.attackpoints - hero1.defencepoints);
                    Console.WriteLine(hero1.healthpoints.ToString(), hero2.healthpoints.ToString());
                    if (hero1.healthpoints <= 0)
                    {
                        Console.WriteLine("Ti zagubi");
                        dbConnect.InsertUpdateDelete($"Insert into battle_result(Userid,Winnerid,Loseid,CreatedDate)" +
                            $" values('{userId}','{hero2.id}','{hero1.id}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");
                        goto Fight;
                    }
                    counter++;
                }
                goto Login;
            }
            else if (inn == "2")
            {
                string userId = dbConnect.Select($"select id from users where userName ='{currentUser.username}' and UserPassword= '{currentUser.password}' ");
                String wins = dbConnect.Select($"select count(b.id) from battle_result b where b.Winnerid in (select id from characters c where c.Userid = '{userId}')");
                String loses = dbConnect.Select($"select count(b.id) from battle_result b where b.Loseid in (select id from characters c where c.Userid = '{userId}')");

                Console.WriteLine("Pobedi: " + wins);
                Console.WriteLine("Zagybi: " + loses);
                /*foreach (DataRow dr in battleresults.Tables[0].Rows)
                {
                    Console.WriteLine(string.Format("Wins:{0}", dr["CharacterName"].ToString()));
                    Console.WriteLine(string.Format("CharacterType:{0}", dr["CharacterType"].ToString()));
                    Console.WriteLine(string.Format("AttackPoints:{0}", dr["AttackPoints"].ToString()));
                    Console.WriteLine(string.Format("DefencePoints:{0}", dr["DefencePoints"].ToString()));
                }*/
                goto Login;
            }
            else if (inn == "3")
            {

            }
        }
    }
}
    

