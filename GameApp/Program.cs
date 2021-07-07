using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    //Named Constants
    //Constant Value is - int
    public enum Options
    {
        BASIC=1,INTERMEDIATE,ADVANCED
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word Guess Game");
            
            string message = string.Format("Enter Your Choice {0}->Basic , {1}->Intermediate ,{2}->Advanced",Options.BASIC,Options.INTERMEDIATE,Options.ADVANCED);// 1->Basic,2->Intermediate
            //String Interpollation 
            string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
            Console.WriteLine(displayMessage);
            Options _choice =(Options)Int32.Parse( Console.ReadLine());
            switch (_choice)
            {
                case Options.BASIC:
                    Console.WriteLine("Basic Level");
                    //Use Reflection  
                    //Assembly Load
                    System.Reflection.Assembly basicLevelLib = 
      System.Reflection.Assembly.LoadFile(@"C:\Users\user\source\repos\excelsoft\Examples\GameApp\bin\Debug\LevelLibs\BasicLevelLib.dll");
                    // Search For Class - BasicLevelType
                   System.Type basicLevelTypeClassRef= basicLevelLib.GetType("BasicLevelLib.BasicLevelType");
                    if (basicLevelTypeClassRef != null)
                    {
                        if (basicLevelTypeClassRef.IsClass)
                        {
                            //Instantiate Type
                            //BasicLevelLib.BasicLevelType objref=new BasicLevelLib.BasicLevelType() ; Early Binding
                           Object objRef =System.Activator.CreateInstance(basicLevelTypeClassRef); //LateBinding Code
                            //Discove Method
                          System.Reflection.MethodInfo _methodRef=  basicLevelTypeClassRef.GetMethod("Play");
                            if (!_methodRef.IsStatic)
                            {
                                //Invoke NonStatic Method
                                // string Play(string playerName, int earlierPoints){}
                                //object result=  _methodRef.Invoke(objRef, new object[] {"Tom",20 });
                                object result =  _methodRef.Invoke(objRef, new object[] {});
                                Console.WriteLine(result.ToString());
                            }

                        }

                    }
                     break;
                case Options.INTERMEDIATE:
                    Console.WriteLine("Intermediate Level");
                     break;
                case Options.ADVANCED:
                    Console.WriteLine("Advanced Level");
                    break;
                
            }

        }
    }
}
