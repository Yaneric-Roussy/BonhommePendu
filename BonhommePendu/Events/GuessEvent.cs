using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter)
        {
            // TODO: Commencez par ICI
            Events = new List<GameEvent>();
            GuessedLetterEvent guessedLetterEvent = new GuessedLetterEvent(gameData, letter);
            Events.Add(guessedLetterEvent);


            bool letterFound = false;
            for (int i = 0; i < gameData.RevealedWord.Length; i++)
            {
                if(gameData.HasSameLetterAtIndex(letter, i))
                {
                    letterFound = true;
                    RevealLetterEvent revealLetterEvent = new RevealLetterEvent(gameData, letter, i);
                    Events.Add(revealLetterEvent);
                }
            }

            string test = gameData.Word;

            if (!letterFound)
            {
                WrongGuessEvent wrongGuessEvent = new WrongGuessEvent(gameData);
                Events.Add(wrongGuessEvent);
            }


        }
    }
}
