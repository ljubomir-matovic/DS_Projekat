using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_58_2020.Models
{
    public enum ResponseType { ALREADY_OPENED,OPENED_ONE,RIGHT_GUESS,WRONG_GUESS }
    public class GameControllerResponse:ICloneable
    {
        public Card card1;
        public Card card2;
        public ResponseType responseType;

        public GameControllerResponse()
        {
        }
        public GameControllerResponse(ResponseType responseType)
        {
            this.responseType = responseType;
        }

        public object Clone()
        {
            GameControllerResponse response = new GameControllerResponse(this.responseType);
            response.card1 = (Card)card1.Clone();
            response.card2 = (Card)card2.Clone();
            return response;
        }
    }
}
