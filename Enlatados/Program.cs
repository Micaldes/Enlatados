// See https://aka.ms/new-console-template for more information
namespace Enlatados;


//CLASE PRINCIPAL DEL JUEGO, SE ENCARGA DE INICIALIZAR EL BUCLE DE JUEGO
class Program
{
    static void Main(string[] args)
    {
        GameLoop game = new GameLoop();
        game.Run();
    }
}







