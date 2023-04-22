using GameFramework.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.State
{
    public class State
    {
        private List<Task> _currentState;

        private bool continueReading = true;
        protected TraceSource ts = new TraceSource("Tracing Creature State");
        protected const String CONFIG_FILE = "StateConfiguration.xml";

        private readonly int NewState;
        private List<ChangeState> changeState= new List<ChangeState>();
        private List<Decision> decision= new List<Decision>();
        public State CurrentState { get; set; }
        public State CreatureState { get; private set; }


        public State(ChangeState currentState)
        {
            StateConfiguration conf = new StateConfiguration();
            conf.StateType = nameof(State);

            SetupState(conf);
        }

        public State()
        {
        }

        public void SetupState(StateConfiguration conf)
        {
            throw new NotImplementedException();
        }

        public void UpdateState()
        {
            foreach (ChangeState change in changeState) 
            {
                bool result = false;
                foreach (var decision in decision)
                {
                    result = decision.MakeDecision();
                    if (result == false)
                        break;
                }
                if (result)
                {
                    if (change.DefenseState != null)
                    {
                        CreatureState.changeState.Add(change.DefenseState);
                        ts.TraceEvent(TraceEventType.Information, NewState, "new stage");
                        return;
                        
                    }

                    else if (change.AttackState != null) 
                    {
                        CreatureState.changeState.Add(change.AttackState);
                    }
                }
                else
                {
                    if (change.IdleState!= null) 
                    {
                        CreatureState.changeState.Add(change.IdleState);
                    }
                }
            }
        }

        public void Start()
        {
            TraceListener traceListener = new ConsoleTraceListener();
            TraceListener fileListener = new TextWriterTraceListener(new StreamWriter("TraceServer.txt"));
            TraceListener xmlListener = new XmlWriterTraceListener(new StreamWriter("TraceServer.xml"));

            /// add switch and different listeners

            ts.Switch = new SourceSwitch("Server Log", "All");
            ts.Listeners.Add(traceListener);
            ts.Listeners.Add(fileListener);
            xmlListener.Filter = new EventTypeFilter(SourceLevels.Error);
            ts.Listeners.Add(xmlListener);

            TcpListener listener = new TcpListener(IPAddress.Any, NewState);
            listener.Start();
            //Console.WriteLine("The server is now running");
            ts.TraceEvent(TraceEventType.Information, NewState, "This is information");
            Task.Run(() => ContinueReading());

            while (continueReading)
            {
                if (!listener.Pending())
                {
                    Thread.Sleep(1000);
                    continue;
                }
                TcpClient client = listener.AcceptTcpClient();
                //Console.WriteLine("Incomming client");
                ts.TraceEvent(TraceEventType.Information, NewState, "This is information");
                //Console.WriteLine($"remote (ip,port) = ({client.Client.RemoteEndPoint})");
                ts.TraceEvent(TraceEventType.Error, 567, "This is an error");

                Task.Run(() =>
                {
                    TcpClient tcpClient = client;
                    DoOneState(client);
                    client.Close();
                });
            }





            ts.TraceEvent(TraceEventType.Information, NewState, "This is information");
            ts.TraceEvent(TraceEventType.Warning, NewState, "This is a warning");
            ts.TraceEvent(TraceEventType.Error, 567, "This is an error");
            ts.TraceEvent(TraceEventType.Critical, 567, "THIS IS CRITICAL!!");

            ts.Close();
        }

        private void ContinueReading()
        {

            TcpListener listener = new TcpListener(IPAddress.Any, NewState + 1);
            listener.Start();
            ts.TraceEvent(TraceEventType.Information, NewState, "Continue Reading");


            while (continueReading)
            {
                TcpClient client = listener.AcceptTcpClient();

                continueReading = false;

                client.Close();



            }
        }

        private void DoOneState(TcpClient client)
        {

        }


    }
}
