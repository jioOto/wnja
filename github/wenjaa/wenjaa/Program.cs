using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {




            string voltar;
            string senha = null;
            string inicio = null;
            string login = null;
            string tell = null;
            string email = null;
            string endereco = null;
            string cpf = null;

            inicio = "sim";
            
            while (inicio == "sim")
            {
                kiki:
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t  ----------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t  |  MENU  |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t  ----------");

                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("----------------------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("| 1 == Cadastro            |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("| 2 == Login               |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("| 3 == Visualizar Produtos |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("| 4 == Achar Produto       |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("----------------------------");


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nEscolha uma ação: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                var lercod = Console.ReadLine();
                Console.ResetColor();


                if (lercod == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("---------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("| CADASTRO |");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("---------");


                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Digite seu login: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    login = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Digite sua senha: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    senha = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Digite seu telefone: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    tell = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Digite seu email: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    email = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Digite seu CEP: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    endereco = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Digite seu CPF: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    cpf = Console.ReadLine();

                    MySqlConnection cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                    cnn.Open();
                    MySqlCommand acc = new MySqlCommand("insert into cadastro (id, login, senha, telefone, email, endereco, cpf) values (null, ?, ?, ?, ?, ?, ?)", cnn);
                    acc.Parameters.Add("@login", MySqlDbType.VarChar, 25).Value = login;
                    acc.Parameters.Add("@senha", MySqlDbType.VarChar, 25).Value = senha;
                    acc.Parameters.Add("@telefone", MySqlDbType.VarChar, 15).Value = tell;
                    acc.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = email;
                    acc.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = endereco;
                    acc.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = cpf;

                    acc.ExecuteNonQuery();




                    Console.WriteLine("\nCADASTRO REALIZADO COM SUCESSO. ");
                    Console.ResetColor();
                    Console.Write("\nVoltar para o menu? (sim/nao) ");
                    inicio = Console.ReadLine();
                }
                if (lercod == "2")
                {



                    Console.Clear();
                    Console.WriteLine("Digite o Login: \n");
                    login = Console.ReadLine();

                    Console.WriteLine("Digite a Senha: \n");
                    senha = Console.ReadLine();

                    MySqlConnection cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                    cnn.Open();

                    MySqlCommand acc = new MySqlCommand("select login, senha from cadastro where login = ? and senha = ?", cnn);
                    acc.Parameters.Clear();

                    acc.Parameters.Add("@login", MySqlDbType.VarChar, 25).Value = login;
                    acc.Parameters.Add("@senha", MySqlDbType.VarChar, 25).Value = senha;


                    MySqlDataReader reader;
                    reader = acc.ExecuteReader();




                    if (reader.Read())
                    {
                    erro1:

                        int cod = default;

                        Console.Clear();
                        Console.WriteLine("===========");
                        Console.WriteLine("Logado.....");
                        Console.WriteLine("===========");

                        Console.WriteLine("1 == Comprar");
                        Console.WriteLine("\nDigite o cód: ");
                        try { cod = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception)
                        {
                            Console.WriteLine("Digite somente número");
                            Console.ReadKey();
                            goto erro1;

                        }

                        cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                        cnn.Open();

                        acc = new MySqlCommand("select * from produtos", cnn);
                        acc.Parameters.Clear();
                        acc.Parameters.Add("@id", MySqlDbType.Int32).Value = cod;


                        MySqlDataReader rd;
                        rd = acc.ExecuteReader();



                        if (rd.Read())
                        {
                            double cPreco = 0;
                            double bPreco = 0;


                            int aId = rd.GetInt32(rd.GetOrdinal("id"));
                            string aNome = rd.GetString(rd.GetOrdinal("nomeproduto"));
                            double aPreco = rd.GetDouble(rd.GetOrdinal("preco"));
                            string aInfProd = rd.GetString(rd.GetOrdinal("infproduto"));

                            if (rd.Read())
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Codigo:{0}\tNome:{1}\t\tPreço:{2}\tInfor:{3}", aId.ToString(), aNome, aPreco.ToString("n"), aInfProd);
                                Console.Write("Deseja comprar mais 1 produto? (sim/nao): ");
                                voltar = Console.ReadLine();
                                cPreco = aPreco;
                                string resposta;

                                while (voltar == "sim")
                                {
                                comprar:
                                    cPreco = cPreco + bPreco;


                                    cnn.Close();
                                    cod = default;
                                    Console.Clear();
                                    Console.WriteLine("1 == Produtos");
                                    Console.WriteLine("\nDigite o cód: ");
                                    cod = Convert.ToInt32(Console.ReadLine());
                                    cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                                    cnn.Open();

                                    acc = new MySqlCommand("select id, nomeproduto, preco, infproduto from produtos where id = ?", cnn);
                                    acc.Parameters.Clear();
                                    acc.Parameters.Add("@id", MySqlDbType.Int32).Value = cod;

                                    rd = acc.ExecuteReader();

                                    if (rd.Read())
                                    {

                                        if (true)
                                        {

                                            aId = rd.GetInt32(rd.GetOrdinal("id"));
                                            aNome = rd.GetString(rd.GetOrdinal("nomeproduto"));
                                            bPreco = rd.GetDouble(rd.GetOrdinal("preco"));
                                            aInfProd = rd.GetString(rd.GetOrdinal("infproduto"));
                                            Console.WriteLine("Codigo:{0}\tNome:{1}\t\tPreço:{2}\tInfor:{3}", aId.ToString(), aNome, bPreco.ToString("n"), aInfProd);

                                            cnn.Close();
                                            Console.WriteLine("");
                                            Console.WriteLine("Deseja comprar mais 1 produto?");
                                            voltar = Console.ReadLine();

                                            Console.Clear();
                                            if (voltar == "sim")
                                            {
                                                goto comprar;
                                            }
                                            cPreco = cPreco + bPreco;

                                            Console.Clear();
                                            Console.WriteLine("O total a pagar é: " + cPreco.ToString("n"));
                                            Console.WriteLine("Deseja pagar por cartão ou boleto?");

                                            resposta = Console.ReadLine();

                                            if (resposta == "boleto" || resposta == "Boleto")
                                            {

                                                Console.Clear();
                                                Console.WriteLine("Enviaremos um Boleto para o seu email.");
                                                Console.WriteLine("Deseja voltar para o menu?");
                                                Console.ReadLine();
                                                goto kiki;
                                            }
                                            else if (resposta == "Cartão" || resposta == "cartão" || resposta == "Cartao" || resposta == "cartao")
                                            {

                                                Console.WriteLine("Confirme suas credenciais, por favor.");
                                                Console.WriteLine("Confirme o endereço");
                                                string confirmEndereco = Console.ReadLine();

                                                Console.WriteLine("Confirme o cpf");
                                                string confirmCpf = Console.ReadLine();

                                                cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                                                cnn.Open();

                                                acc = new MySqlCommand("select endereco, cpf from cadastro where endereco = ? and cpf = ?", cnn);
                                                acc.Parameters.Clear();
                                                acc.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = confirmEndereco;
                                                acc.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = confirmCpf;

                                                rd = acc.ExecuteReader();

                                                if (rd.Read())
                                                {

                                                    string aEndereco = rd.GetString(rd.GetOrdinal("endereco"));
                                                    string aCpf = rd.GetString(rd.GetOrdinal("cpf"));




                                                    if (confirmEndereco == aEndereco || confirmCpf == aCpf)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Ditigte as informações do Cartão:");
                                                        Console.WriteLine("Provedora");
                                                        string bandeira = Console.ReadLine();
                                                        Console.WriteLine("Numero");
                                                        int numero = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("CVC");
                                                        int cvc = Convert.ToInt32(Console.ReadLine());

                                                        Console.WriteLine("Senha");
                                                        string cSenha = Console.ReadLine();

                                                        Console.Clear();
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Enviaremos o seu item para o cep {0}. Obrigado por escolher os serviços Wenja!", aEndereco);
                                                        cnn.Close();
                                                        Console.ReadKey();

                                                    }
                                                }
                                                Console.Clear();
                                                Console.WriteLine("Vimos que digitou alguma coisa errada, gostaria de tentar novamente?(sim/nao)");
                                                inicio = Console.ReadLine();
                                            }
                                        }
                                    }

                                    else if (rd.Read() == false)
                                    {
                                        Console.WriteLine("erro1");
                                        Console.ReadKey();
                                        voltar = "nao";

                                    }
                                    else
                                    {
                                        Console.WriteLine("erro2");
                                        Console.ReadKey();
                                        voltar = "nao";
                                    }


                                }
                            erro2:
                                Console.Clear();
                                cPreco = cPreco + bPreco;
                                Console.WriteLine("O total a pagar é: " + cPreco.ToString("n"));
                                Console.WriteLine("Deseja pagar por cartão ou boleto?");
                                resposta = Console.ReadLine();
                                if (resposta == "boleto" || resposta == "Boleto")
                                {

                                    Console.Clear();
                                    Console.WriteLine("Enviaremos um Boleto para o seu email.");
                                    Console.WriteLine("Aperte qualquer botão para sair.");
                                    Console.ReadKey();
                                    goto kiki;
                                }
                                else if (resposta == "Cartão" || resposta == "cartão" || resposta == "Cartao" || resposta == "cartao")
                                {

                                    Console.WriteLine("Confirme suas credenciais, por favor.");
                                    Console.WriteLine("Confirme o endereço");
                                    string confirmEndereco = Console.ReadLine();

                                    Console.WriteLine("Confirme o cpf");
                                    string confirmCpf = Console.ReadLine();

                                    cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                                    cnn.Open();

                                    acc = new MySqlCommand("select endereco, cpf from cadastro where endereco = ? and cpf = ?", cnn);
                                    acc.Parameters.Clear();
                                    acc.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = confirmEndereco;
                                    acc.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = confirmCpf;

                                    rd = acc.ExecuteReader();

                                    if (rd.Read())
                                    {

                                        string aEndereco = rd.GetString(rd.GetOrdinal("endereco"));
                                        string aCpf = rd.GetString(rd.GetOrdinal("cpf"));




                                        if (confirmEndereco == aEndereco || confirmCpf == aCpf)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ditigte as informações do Cartão:");
                                            Console.WriteLine("Provedora");
                                            string bandeira = Console.ReadLine();
                                            Console.WriteLine("Numero");
                                            string numero = Console.ReadLine();
                                            Console.WriteLine("CVC");
                                            string cvc = Console.ReadLine();

                                            Console.WriteLine("Senha");
                                            string cSenha = Console.ReadLine();

                                            Console.Clear();
                                            Console.WriteLine("");
                                            Console.WriteLine("Enviaremos o seu item para o cep {0}. Obrigado por escolher os serviços Wenja!", aEndereco);
                                            cnn.Close();
                                            Console.ReadKey();

                                        }
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Vimos que digitou alguma coisa errada, gostaria de tentar novamente?(sim/nao)");
                                    inicio = Console.ReadLine();
                                }

                                cPreco = cPreco + bPreco;
                                Console.WriteLine("O total a pagar é: " + cPreco.ToString("n"));
                                Console.WriteLine("Deseja pagar por cartão ou boleto?");
                                resposta = Console.ReadLine();
                                if (resposta == "boleto" || resposta == "Boleto")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enviaremos um Boleto para o seu email.");
                                    Console.WriteLine("Deseja voltar para o menu? (sim/nao).");
                                    inicio = Console.ReadLine();
                                    Console.ReadKey();
                                    goto kiki;

                                }
                                else if (resposta == "Cartão" || resposta == "cartão" || resposta == "Cartao" || resposta == "cartao")
                                {

                                    Console.WriteLine("Confirme suas credenciais, por favor.");
                                    Console.WriteLine("Confirme o endereço");
                                    string confirmEndereco = Console.ReadLine();

                                    Console.WriteLine("Confirme o cpf");
                                    string confirmCpf = Console.ReadLine();

                                    cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                                    cnn.Open();

                                    acc = new MySqlCommand("select endereco, cpf from cadastro where endereco = ? and cpf = ?", cnn);
                                    acc.Parameters.Clear();
                                    acc.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = confirmEndereco;
                                    acc.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = confirmCpf;

                                    rd = acc.ExecuteReader();

                                    if (rd.Read())
                                    {

                                        string aEndereco = rd.GetString(rd.GetOrdinal("endereco"));
                                        string aCpf = rd.GetString(rd.GetOrdinal("cpf"));




                                        if (confirmEndereco == aEndereco || confirmCpf == aCpf)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ditigte as informações do Cartão:");
                                            Console.WriteLine("Provedora");
                                            string bandeira = Console.ReadLine();
                                            Console.WriteLine("Numero");
                                            int numero = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("CVC");
                                            int cvc = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Senha");
                                            string cSenha = Console.ReadLine();

                                            Console.Clear();
                                            Console.WriteLine("");
                                            Console.WriteLine("Enviaremos o seu item para o cep {0}. Obrigado por escolher os serviços Wenja!", aEndereco);
                                            cnn.Close();
                                            Console.ReadKey();

                                        }
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Vimos que digitou alguma coisa errada, gostaria de tentar novamente?(sim/nao)");
                                    inicio = Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Erro");
                                    Console.ReadKey();
                                    goto erro2;
                                }
                            }

                            else if (rd.Read() == false)
                            {
                                Console.WriteLine("erro1");
                                Console.ReadKey();
                                voltar = "nao";

                            }
                            else
                            {
                                Console.WriteLine("erro2");
                                Console.ReadKey();
                                voltar = "nao";
                            }

                        }
                    }
                    else if (reader.Read() == false)
                    {


                        Console.Clear();
                        Console.WriteLine("Erro ao logar.\n");
                        Console.Write("\nVoltar para o menu : (sim/nao) ");
                        inicio = Console.ReadLine();


                    }
                }
                if (lercod == "3")
                {

                    Console.Clear();
                    Console.WriteLine("--------------");
                    Console.WriteLine("| Visualizar |");
                    Console.WriteLine("--------------");

                    Console.WriteLine("");

                    MySqlConnection cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                    cnn.Open();

                    MySqlCommand acc = new MySqlCommand("select id, nomeproduto, preco, infproduto from produtos", cnn);

                    MySqlDataReader rd;
                    rd = acc.ExecuteReader();

                    while (rd.Read())
                    {
                        int aId = rd.GetInt32(rd.GetOrdinal("id"));
                        string aNome = rd.GetString(rd.GetOrdinal("nomeproduto"));
                        double aPreco = rd.GetDouble(rd.GetOrdinal("preco"));
                        string aInfProd = rd.GetString(rd.GetOrdinal("infproduto"));
                        Console.WriteLine("Codigo:{0}\tNome:{1}\t\tPreço:{2}\tInfor:{3}", aId.ToString(), aNome, aPreco.ToString("n"), aInfProd);

                    }
                    cnn.Close();
                    Console.ReadKey();

                }


                if (lercod == "4")
                {
                    var visu = "sim";

                    while (visu == "sim")
                    {
                        Console.Clear();
                        Console.WriteLine("----------");
                        Console.WriteLine("| Buscar |");
                        Console.WriteLine("----------");
                        string buscar;

                        Console.WriteLine("");

                        MySqlConnection cnn = new MySqlConnection("server=localhost;port=3307;User Id=root;database=wenja;password=usbw");
                        cnn.Open();
                        Console.WriteLine("Digite o nome do produto");
                        string nome;

                        buscar = Console.ReadLine();
                        nome = buscar;
                        MySqlCommand acc = new MySqlCommand("select id, nomeproduto, preco, infproduto from produtos where nomeproduto = ?", cnn);
                        acc.Parameters.Clear();
                        acc.Parameters.Add("@nomeproduto", MySqlDbType.VarChar, 50).Value = buscar;

                        MySqlDataReader rd;
                        rd = acc.ExecuteReader();


                        if (rd.Read())
                        {


                            int aId = rd.GetInt32(rd.GetOrdinal("id"));
                            string aNome = rd.GetString(rd.GetOrdinal("nomeproduto"));
                            double aPreco = rd.GetDouble(rd.GetOrdinal("preco"));
                            string aInfProd = rd.GetString(rd.GetOrdinal("infproduto"));


                            Console.WriteLine("Codigo:{0}\tNome:{1}\t\tPreço:{2}\tInfor:{3}", aId.ToString(), aNome, aPreco.ToString("n"), aInfProd);
                            Console.WriteLine("");
                            Console.WriteLine("Deseja procurar outro produto?(sim/nao)");
                            visu = Console.ReadLine();



                        }

                        else if (rd.Read() == false)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Erro");
                            visu = "nao";
                            Console.ReadKey();
                            visu = "nao";
                        }
                        else
                        {
                            Console.WriteLine("Envie para o administrador o erro: " + rd.Read());
                        }

                        cnn.Close();



                    }
                }

            }
        }
    }
}




