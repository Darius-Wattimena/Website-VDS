using System.Collections.Generic;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.BL
{
    public class CreateList
    {
        public Vraag CreateListVraag(int id)
        {
            var itemTrue = new Antwoord { Context = "", CorrectAntwoord = true, Id = 1};
            var itemFalse = new Antwoord { Context = "", CorrectAntwoord = false, Id = 2 };
            var antwoord = new List<Antwoord> { itemTrue, itemFalse };
            var vraag = new Vraag {Naam = "", AntwoordCollection = antwoord, Id = id};
            return vraag;
        }

        public Antwoord CreateAntwoord(int id)
        {
            var antwoord = new Antwoord {Context = "", CorrectAntwoord = false, Id = id};
            return antwoord;
        }
    }
}