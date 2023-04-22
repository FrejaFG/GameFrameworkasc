using GameFramework.State;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Xml;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

       // State state = new State();
        //state.Start();

        TraceSource ts = new TraceSource("Game Framework");
        ts.Switch = new SourceSwitch("Log Framework", "All");

        TraceListener listener = new ConsoleTraceListener();
        ts.Listeners.Add(listener);

        TraceListener filListener = new TextWriterTraceListener(new StreamWriter("TraceDemo.txt") { AutoFlush = true });
        ts.Listeners.Add(filListener);

        TraceListener xmlListener = new XmlWriterTraceListener(new StreamWriter("TraceDemo.xml") { AutoFlush = true });
        xmlListener.Filter = new EventTypeFilter(SourceLevels.All);
        ts.Listeners.Add(xmlListener);


        TraceListener eventLogListener = new EventLogTraceListener("Application");
        ts.Listeners.Add(eventLogListener);
        Trace.AutoFlush = true;






        ts.TraceEvent(TraceEventType.Information, 567, "This is information");
        ts.TraceEvent(TraceEventType.Warning, 567, "This is warning");
        ts.TraceEvent(TraceEventType.Error, 567, "This is error");
        ts.TraceEvent(TraceEventType.Critical, 567, "This is critical");

       // ts.Flush();
        //ts.Close();

        XmlDocument xml = new XmlDocument();
        xml.Load("StateType.xml");


        Console.WriteLine("State1:");
        XmlNode? State1Node = xml.DocumentElement.SelectSingleNode("State1");
        if (State1Node is not null)
        {
            String str = State1Node.InnerText;
            Console.WriteLine(str);
        }

        Console.WriteLine("State2:");
        XmlNode? State2Node = xml.DocumentElement.SelectSingleNode("State2");
        if (State2Node is not null)
        {
            String str = State2Node.InnerText;
            //int number = int.Parse(str);
            Console.WriteLine(str);
        }

        Console.WriteLine("State3:");
        XmlNode? State3Node = xml.DocumentElement.SelectSingleNode("State3");
        if (State3Node is not null)
        {
            String str = State3Node.InnerText;
           // int number = int.Parse(str);
            Console.WriteLine(str);
        }
    }
}