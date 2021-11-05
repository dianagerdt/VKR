using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASTRALib;

namespace RustabBot_v1._0
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Rastr rastrFromASTRA = new Rastr();
            // Посмотреть все методы и свойства объекта
            // названиеЭкземпляра. затем нажать ctrl + пробел
            //rastrFromASTRA.Load(RG_KOD.RG_REPL, @"D:\Магистратура ТПУ\3 семестр\2.Противоаварийное управление в ЭЭС\файлы растр\регим.rg2", "");
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
