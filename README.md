Se ha expandido la funcionalidad de las siguientes formas:
    - Se ha añadido un sistema de carga de sonidos e imágenes en las carpetas SoundSystem e ImageSystem. No hace falta que conozcais su implementación para usarlos, más adelante os explico cómo.
    - En la carpeta Observer estan las interfaces IObserver e ISubject. SoundSystem es un Observer. El subject que notifica a los observers actualmente es el gameloop (aunque podriamos encapsularlo en un PlayerSession como hacen en el juego de clase).
    - Para que los component puedan notificar a un observer, se ha añadido a la clase GameObject un puntero a Gameloop llamado parent.
    - En la carpeta Eventos hay dos archivos: EventId.cs es un enum con los nombres de los eventos (añadir aquí los que sean necesarios). Además está la clase PlayerEventData, que de momento solo guarda un EventID, pero se pueden añadir atributos que pasen mas informacion relativa al evento si es necesario.
    - Se ha implementado el paradigma ServiceLocator mediante la interfaz IService y la clase ServiceLocator.cs. Los servicios que ofrece de momento son SoundSystem e ImageSystem (Se asignan en el Init del GameLoop).
    - Para probar el SoundSystem he programado desde el PlayerInputComponent que se mande un evento de disparo al pulsar el boton izquierdo del ratón. Desde Gameloop se notifica a los observers mediante NotifyObservers().
    - Para probar el ImageSystem, ahora las imágenes se cargan usando el ServiceLocator (el Cursor y el Fondo desde GameLoop).

COMO AÑADIR Y UTILIZAR UN SONIDO
    1. Meter en la carpeta Enlatados/Assets/Sounds
    2. En el archivo Services/SoundSystem/SoundAssets.cs, escribir en el enum SoundID el nombre con el que vayas a referirte al sonido
    
    3. También en SoundAssets.cs en el diccionario asociar el Id al nombre del archivo (Si lo habeis puesto en la carpeta que es, NO
    hay que poner el directorio, solo el nombre y su extensión).
    4. Los sonidos funcionan mediante el paradigma Observer/Subject (evento reactivo). El Subject actualmente es el GameLoop, y el Observer el SoundLoader. Para invocar un evento desde, por ejemplo, un component:

        using static EventId;

        Owner.Parent.SendPlayerEvent(PlayerShoots);

    5. En la función de SoundLoader OnUpdate(PlayerEventData data) programar el comportamiento en el caso del evento:

        using static EventId;
        using static SoundAssets.SoundID;

        if(data.EventType == PlayerShoots)
        {
            _playSoundQueue.Enqueue(Shoot);
        }

COMO AÑADIR Y UTILIZAR UNA TEXTURA
    1. Meter en la carpeta Enlatados/Assets/Images
    2. En el archivo Services/ImageSystem/ImageAssets.cs, escribir en el enum ImageID el nombre con el que vayas a referirte a la textura
    en el código. 
    3. También en ImageAssets.cs en el diccionario asociar el Id al nombre del archivo (Si lo habeis puesto en la carpeta que es, NO
    hay que poner el directorio, solo el nombre y su extensión).
    4. Para usar una textura hay que llamar al serviceLocator de la siguiente manera:

        ServiceLocator.GetService<ImageLoader>().GetTexture(Cursor)
        ServiceLocator.GetService<ImageLoader>().GetTexture(Background)

