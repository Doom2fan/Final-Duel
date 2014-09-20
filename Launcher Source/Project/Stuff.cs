using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace Launcher {
    public enum Trilean {
        Indeterminate = 0,
        False = 1,
        True = 2,
    }

    public class Game {
        public static bool Running = false;
        public static int ProcessID = 0;
    }
}