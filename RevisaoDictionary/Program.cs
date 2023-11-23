string path = @"c:\temp\teste.txt";
try
{
    using StreamReader sr = File.OpenText(path);
    Dictionary<string, int> RegistroVotos = new Dictionary<string, int>();

    while (!(sr.EndOfStream))
    {
        string[] linha = sr.ReadLine().Split(',');
        string Candidato = linha[0];
        int NumeroDeVotos = int.Parse(linha[1]);
        if (RegistroVotos.ContainsKey(Candidato))
        {
            RegistroVotos[Candidato] += NumeroDeVotos;
        }
        else
        {
            RegistroVotos.Add(Candidato, NumeroDeVotos);
        }
    }
    sr.Close();
    Console.WriteLine();

    Console.WriteLine("RELATÓRIO VOTAÇÃO: ");
    foreach (KeyValuePair<string, int> Registro in RegistroVotos)
    {
        Console.WriteLine($"{Registro.Key}: {Registro.Value}");
    }
}
catch(FileNotFoundException e)
{
    Console.WriteLine("ERRO: " + e.Message);
}
catch(IOException e)
{
    Console.WriteLine("ERRO: " + e.Message);
}