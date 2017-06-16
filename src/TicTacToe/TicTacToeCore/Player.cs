using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PhilChuang.Apps.TicTacToe
{
    public class Player
    {
        /// <summary>
        /// The player's mark (traditionally X or O)
        /// </summary>
        public char Mark { get; set; }

        /// <summary>
        /// The player's name
        /// </summary>
        public string Name { get; set; }

        public Player(string name, char mark)
        {
            this.Name = name;
            this.Mark = mark;
        }
    }
}
