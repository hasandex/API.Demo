namespace API.Demo.Models
{
    public static class Seeding
    {
        public static List<Player> Players()
        {
            List<Player> players = new List<Player>
            {
                new Player
    {
        Id = "1",
        FirstName = "Lionel",
        LastName = "Messi",
        Nationality = "Argentina",
        Age = "35",
        Height = 1.70m,
        Weight = 72m,
        Club = "Inter Miami",
        PreviousClubs = new List<string> { "Barcelona", "Paris Saint-Germain" }
    },
                new Player
    {
        Id = "2",
        FirstName = "Cristiano",
        LastName = "Ronaldo",
        Nationality = "Portugal",
        Age = "38",
        Height = 1.87m,
        Weight = 83m,
        Club = "Al Nassr",
        PreviousClubs = new List<string> { "Manchester United", "Juventus", "Real Madrid" }
    },
    new Player
    {
        Id = "3",
        FirstName = "Neymar",
        LastName = "da Silva",
        Nationality = "Brazil",
        Age = "31",
        Height = 1.75m,
        Weight = 68m,
        Club = "Al Hilal",
        PreviousClubs = new List<string> { "Paris Saint-Germain", "Barcelona" }
    },
    new Player
    {
        Id = "4",
        FirstName = "Kylian",
        LastName = "Mbappé",
        Nationality = "France",
        Age = "24",
        Height = 1.78m,
        Weight = 73m,
        Club = "Paris Saint-Germain",
        PreviousClubs = new List<string> { "AS Monaco" }
    },
    new Player
    {
        Id = "5",
        FirstName = "Kevin",
        LastName = "De Bruyne",
        Nationality = "Belgium",
        Age = "32",
        Height = 1.81m,
        Weight = 70m,
        Club = "Manchester City",
        PreviousClubs = new List<string> { "Chelsea", "Wolfsburg" }
    },
    new Player
    {
        Id = "6",
        FirstName = "Mohamed",
        LastName = "Salah",
        Nationality = "Egypt",
        Age = "31",
        Height = 1.75m,
        Weight = 71m,
        Club = "Liverpool",
        PreviousClubs = new List<string> { "AS Roma", "Chelsea", "Fiorentina" }
    },
    new Player
    {
        Id = "7",
        FirstName = "Gareth",
        LastName = "Bale",
        Nationality = "Wales",
        Age = "34",
        Height = 1.83m,
        Weight = 74m,
        Club = "Los Angeles FC",
        PreviousClubs = new List<string> { "Tottenham Hotspur", "Real Madrid" }
    },
    new Player
    {
        Id = "8",
        FirstName = "Virgil",
        LastName = "van Dijk",
        Nationality = "Netherlands",
        Age = "32",
        Height = 1.93m,
        Weight = 92m,
        Club = "Liverpool",
        PreviousClubs = new List<string> { "Southampton", "Celtic" }
    },
    new Player
    {
        Id = "9",
        FirstName = "Sadio",
        LastName = "Mané",
        Nationality = "Senegal",
        Age = "31",
        Height = 1.75m,
        Weight = 69m,
        Club = "Al Nassr",
        PreviousClubs = new List<string> { "Liverpool", "Southampton", "Red Bull Salzburg" }
    },
    new Player
    {
        Id = "10",
        FirstName = "Robert",
        LastName = "Lewandowski",
        Nationality = "Poland",
        Age = "35",
        Height = 1.85m,
        Weight = 79m,
        Club = "FC Barcelona",
        PreviousClubs = new List<string> { "Bayern Munich", "Borussia Dortmund" }
    }
            };
            return players;
        }
    }
}
