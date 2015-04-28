using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugClassDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            string sProdName = "Widget";
            int iUnitQty = 100;
            double dUnitCost = 1.03;


            /* By default, the Debug class produces messages to the output window, not the 
             * console UI. The stack trace is read from top to bottom.
             * */

            //To show we are starting to debug
            Debug.WriteLine("Debug Information-Product Starting ");
            Debug.Indent();

            //to display content of selected variables
            Debug.WriteLine("The product name is " + sProdName);
            Debug.WriteLine("The available units on hand are " + iUnitQty.ToString());
            Debug.WriteLine("The per unit cost is " + dUnitCost.ToString());

            //Can also use to display namespace and the class name for an existent object
            System.Xml.XmlDocument oxml = new System.Xml.XmlDocument();
            Debug.WriteLine(oxml);

            //To organize output, include a category as optional param. The 2nd 
            //param formats "Field: message"
            Debug.WriteLine("The product name is " + sProdName, "Field");
            Debug.WriteLine("The units on hand are" + iUnitQty, "Field");
            Debug.WriteLine("The per unit cost is" + dUnitCost.ToString(), "Field");
            Debug.WriteLine("Total Cost is  " + (iUnitQty * dUnitCost), "Calc");

            //For conditional output, use writelineif
            //This only shows conditions (the first parameter) that are true
            Debug.WriteLineIf(iUnitQty > 50, "This message WILL appear");
            Debug.WriteLineIf(iUnitQty < 50, "This message will NOT appear");

            //to show conditions that are false, use Assert
            Debug.Assert(dUnitCost > 1, "Message will NOT appear");
            Debug.Assert(dUnitCost < 1, "Message will appear since dUnitcost < 1 is false");

            //Create a TextWriterTraceListener object for console (tr1) and for a text file name Output.txt
            //then add each object to the Debug listeners collection
            TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(tr1);
            TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText("Output.txt"));
            Debug.Listeners.Add(tr2);

            //For readability, use theunindent method to remove the indentation 
            Debug.Unindent();
            Debug.WriteLine("Debug Information-Product Ending");

            //To make sure Listener receives all its output, call the flush method for the Debug class buffers
            Debug.Flush();
            Console.ReadKey();
        }
    }
}
