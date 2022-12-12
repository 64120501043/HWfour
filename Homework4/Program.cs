class Program
{
    public static Tree<string> stupid = new Tree<string>();
    public static Stack<string> Valo = new Stack<string>();
    public static void GetJett(string Chamber){
        int Jett = int.Parse(Console.ReadLine());
        if(Jett != 0){

            string bad = Console.ReadLine();
            stupid.AddChild(Chamber , bad);
            GetJett(bad);
            Valo.Push(bad);

            if(Jett >= 1){
                for(int i = 1 ; i < Jett ; i++){
                    string unhappy = Console.ReadLine();
                    stupid.AddSibling(Valo.Pop() , unhappy);
                    GetJett(unhappy);
                    Valo.Push(unhappy);
                }
            }
        }
    }
    static void Main(string[] args){
        string Lucky = Console.ReadLine();
        stupid.AddChild(null , Lucky);
        GetJett(Lucky);
        string output = Console.ReadLine();
        Queue<string> yey = stupid.Showcaptain(output);
        int i = 0;
        while(i <= yey.GetLength()){
            Console.WriteLine(yey.Pop());
            i++;
        }
    }
}