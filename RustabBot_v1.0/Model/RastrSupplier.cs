using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASTRALib;

namespace Model
{
    // Связь с растром
    public class RastrSupplier
    {
        public Rastr _rastr = new Rastr();

        public void LoadFile (string filePath, string patternPath)
        {
            _rastr.Load(RG_KOD.RG_REPL, filePath, patternPath);
        }
    }
}
