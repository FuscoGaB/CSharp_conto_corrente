using conto_corrente;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Conto c1 = new Conto("01", "dottore", "mediolanum", 0);
        Conto c2 = new Conto("02", "strada", "mediolanum", 0);

        bool esci = false;
        string risposta = "";
        string risposta2 = "";
        double preleva = 0;

        Carta ca1 = new Carta("011", "123", c1);
        Carta ca2 = new Carta("012", "567", c2);

        Console.WriteLine("Inserisci PIN conto: ");
        string pinC = Console.ReadLine();

        while (!esci){
            do
            {
                Console.WriteLine("Che operazione vuoi fare? (deposita, preleva, bonifico, deposita_carta, preleva_carta, stop)");
                risposta = Console.ReadLine();

                switch (risposta)
                {
                    case "deposita":
                        do
                        {
                            Console.WriteLine("Inserisci PIN conto: ");
                            risposta2 = Console.ReadLine();
                            if (risposta2 == pinC)
                            {
                                Console.WriteLine("Pin corretto! Carta sbloccata!");
                            }
                            else
                            {
                                Console.WriteLine("Pin errato! Carta bloccata!");
                            }
                        } while (risposta2 != pinC);
                        Console.WriteLine("Inserisci il credito da depositare: (in questo momento hai " + c1.Saldo + "$)");
                        double deposita = Convert.ToDouble(Console.ReadLine());

                        //funzione nel conto
                        c1.DepositaDenaro(deposita);

                        Console.WriteLine("Ora hai " + c1.Saldo + "$");
                        break;

                    case "deposita_carta":
                        do
                        {
                            Console.WriteLine("Inserisci PIN conto: ");
                            risposta2 = Console.ReadLine();
                            if (risposta2 == pinC)
                            {
                                Console.WriteLine("Pin corretto! Carta sbloccata!");
                            }
                            else
                            {
                                Console.WriteLine("Pin errato! Carta bloccata!");
                            }
                        } while (risposta2 != pinC);
                        Console.WriteLine("Inserisci il credito da depositare: (in questo momento hai " + c1.Saldo + "$)");
                        double depositac = Convert.ToDouble(Console.ReadLine());

                        //funzione nella carta
                        ca1.Deposita(depositac);

                        Console.WriteLine("Ora hai " + c1.Saldo + "$");
                        break;

                    case "preleva":
                        do
                        {
                            Console.WriteLine("Inserisci PIN conto: ");
                            risposta2 = Console.ReadLine();
                            if (risposta2 == pinC)
                            {
                                Console.WriteLine("Pin corretto! Carta sbloccata!");
                            }
                            else
                            {
                                Console.WriteLine("Pin errato! Carta bloccata!");
                            }
                        } while (risposta2 != pinC);
                        do
                        {
                            Console.WriteLine("Inserisci il credito da prelevare: (in questo momento hai " + c1.Saldo + "$)");
                            preleva = Convert.ToDouble(Console.ReadLine());
                            
                            if (preleva <= 0)
                                Console.WriteLine("Non puoi aggiungerti soldi.");
                            if (preleva > c1.Saldo)
                            {
                                Console.WriteLine("Non puoi prelevare più soldi di quanti ne hai.");
                                esci = true;
                                break;
                            }

                        } while (preleva <= 0 || preleva > c1.Saldo);

                        //funzione nel conto
                        c1.PrelevaDenaro(preleva);

                        Console.WriteLine("Ora hai " + c1.Saldo + "$");
                        break;

                    case "preleva_carta":
                        do
                        {
                            Console.WriteLine("Inserisci PIN conto: ");
                            risposta2 = Console.ReadLine();
                            if (risposta2 == pinC)
                            {
                                Console.WriteLine("Pin corretto! Carta sbloccata!");
                            }
                            else
                            {
                                Console.WriteLine("Pin errato! Carta bloccata!");
                            }
                        } while (risposta2 != pinC);
                        do
                        {
                            Console.WriteLine("Inserisci il credito da prelevare: (in questo momento hai " + c1.Saldo + "$)");
                            preleva = Convert.ToDouble(Console.ReadLine());

                            if (preleva <= 0)
                                Console.WriteLine("Non puoi aggiungerti soldi.");
                            if (preleva > c1.Saldo)
                            {
                                Console.WriteLine("Non puoi prelevare più soldi di quanti ne hai.");
                                esci = true;
                                break;
                            }

                        } while (preleva <= 0 || preleva > c1.Saldo);
                        Console.WriteLine("Inserisci il credito da prelevare: (in questo momento hai " + c1.Saldo + "$)");
                        double prelevac = Convert.ToDouble(Console.ReadLine());

                        //funzione nella carta
                        ca1.Preleva(prelevac);

                        Console.WriteLine("Ora hai " + c1.Saldo + "$");
                        break;

                    case "bonifico":
                        do
                        {
                            Console.WriteLine("Inserisci PIN conto: ");
                            risposta2 = Console.ReadLine();
                            if (risposta2 == pinC)
                            {
                                Console.WriteLine("Pin corretto! Carta sbloccata!");
                            }
                            else
                            {
                                Console.WriteLine("Pin errato! Carta bloccata!");
                            }
                        } while (risposta2 != pinC);
                        do
                        {
                            Console.WriteLine("Inserisci il credito da trasferire: (in questo momento hai " + c1.Saldo + "$)");
                            preleva = Convert.ToDouble(Console.ReadLine());
                            if (preleva <= 0 || preleva > c1.Saldo)
                                Console.WriteLine("Non puoi trasferire più soldi di quanti ne hai.");
                        } while (preleva <= 0 || preleva > c1.Saldo);

                        //funzione nel conto
                        c1.Bonifico(preleva, c2);

                        Console.WriteLine("Ora hai " + c1.Saldo + "$ nel primo conto");
                        Console.WriteLine("Ora hai " + c2.Saldo + "$ nel secondo conto");
                        break;

                    case "stop":
                        Console.WriteLine("Programma terminato.");
                        break;

                    default:
                        Console.WriteLine("Operazione non riconosciuta. Riprova.");
                        break;
                }
            } while (risposta != "stop");
        }
    }
}
