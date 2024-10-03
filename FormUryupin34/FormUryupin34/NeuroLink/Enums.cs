
namespace FormUryupin34.NeuroLink
{

    enum NeuronType //Тип нейрона
    {
        Hidden, //Нейрон скрытого слоя
        Output  //Нейрон выходного слоя
    }

    enum NetworkMode
    {
        Train,  //ОБУЧЕНИЕ
        Test,   //ТЕСТ
        Recogn  //РАСПОЗНОВАНИЕ
    }

    enum MemoryMode
    {
        GET,
        SET,
        INIT
    }
}
