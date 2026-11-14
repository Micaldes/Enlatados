namespace Enlatados.Scenes
{
    public class StateManager // Singleton
    {
        private IState estado;
        private static StateManager instance;

        private StateManager() { }

        public static StateManager getInstance()
        {
            if (instance == null)
            {
                instance = new StateManager();
            }
            return instance;
        }
        //---------------------------------------
        public IState GetEstado() => estado;

        public void changeState(States StateID)
        {

            //Cuando abandonamos un estado, lo limpiamos y no antes de entrar a otro, mejor asi
            //  Si ya hay un estado activo, lo limpiamos antes de cambiar
            if (estado != null)
            {
                estado.Exit();
            }

            //  Asignamos la nueva instancia según el enum
            switch (StateID)
            {
                case States.State_Menu:
                    estado = new Enlatados.Scenes.Menu.Menu();
                    break;
                case States.State_Core: // Ajusta el nombre según tu enum
                    estado = new Enlatados.Scenes.Core.Code.Game();
                    break;
                case States.State_Settings:
                    estado = new Enlatados.Scenes.Settings.Settings();
                    break;
                case States.State_Credits: // Ajusta el nombre según tu enum
                    estado = new Enlatados.Scenes.Credits.Credits();
                    break;

            }

            estado.Enter();
        }
    }
}