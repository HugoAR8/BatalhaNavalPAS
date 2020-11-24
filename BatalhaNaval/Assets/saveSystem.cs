using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem 
{

    public static void SaveGame()
    {
        //Criptografia dos dados do save
        BinaryFormatter formatter = new BinaryFormatter();

        //Caminho do arquivo = o local que o jogo está
        string path = Application.persistentDataPath + "/game.txt";

        //Criando arquivo
        FileStream stream = new FileStream(path, FileMode.Create);

        //Puxando os dados do player
        PlayerData data = new PlayerData();

        //Formatando os dados e escrevendo.
        formatter.Serialize(stream, data);

        //Fechando a stream de dados.
        stream.Close();
    }

    public static PlayerData loadGame()
    {
        //Caminho do arquivo = o local que o jogo está
        string path = Application.persistentDataPath + "/game.txt";
        if(File.Exists(path))
        {
            //Criptografia dos dados do save
            BinaryFormatter formatter = new BinaryFormatter();

            //Abrindo arquivo
            FileStream stream = new FileStream(path, FileMode.Open);
            
            //Descriptografando dados
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            //Fechando a stream de dados pra evitar erros
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Arquivo de save não encontrado");
            return null;
        }
    }

}
