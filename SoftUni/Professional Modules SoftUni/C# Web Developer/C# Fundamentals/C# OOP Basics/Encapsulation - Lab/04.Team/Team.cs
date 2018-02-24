using System;
using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    //public readonly List<Person> FirstTeam = new List<Person>();
    //public readonly List<Person> ReserveTeam = new List<Person>();


    public Team(string name)
    {
        this.Name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();

        //////////
        //this.firstTeam = FirstTeam;
        //this.reserveTeam = ReserveTeam;
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }

   
  public List<Person> FirstTeam
  {
      get { return firstTeam; }
      private set { firstTeam = value; }
  }


  public List<Person> ReserveTeam          
  {
      get { return reserveTeam; }
      private set { reserveTeam = value; }
  }

    public static string Count(Team firstTeam, Team secondTeam)
    {
      return  $"First team has {firstTeam.firstTeam.Count} players.\nReserve team has {secondTeam.reserveTeam.Count} players. ";
    }


}