using ConversorDados.Context;
using Microsoft.Data.SqlClient;
using Vinum.Core.Negocios;
using Vinum.Entidades.Enums.Modelos;
using Vinum.Entidades.Modelos;

namespace ConversorDados
{
    public partial class FrmConversorDados : Form
    {
        public FrmConversorDados()
        {
            InitializeComponent();
        }

        private void btnPlano_Click(object sender, EventArgs e)
        {
            List<V090Pla> lista = new List<V090Pla>();
            V090Pla model = null!;
            V090PlaNG _NG = new V090PlaNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [ClubePlano]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V090Pla();
                        model.CodPla = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomPla = leitor["Nome"].ToString();
                        model.VlrPla = Convert.ToDecimal(leitor["Valor"].ToString());
                        if (leitor["ImpAdEscolinha"].ToString().Equals("0"))
                            model.ImpPla = false;
                        else model.ImpPla = true;
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                    leitor.Close();
                }
                conexao.Close();
            }

            //Inserir no PostgreSQL.
            foreach (V090Pla item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Plano Convertido com Sucesso.");
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            List<V030Est> lista = new List<V030Est>();
            V030Est model = null;
            V030EstNG _NG = new V030EstNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Estado]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V030Est();
                        model.CodEst = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomEst = leitor["Nome"].ToString();
                        model.SigEst = leitor["UF"].ToString();
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir no PostgreSQL.
            foreach (V030Est item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela Estado Convertido com Sucesso.");
        }

        private void btnCidade_Click(object sender, EventArgs e)
        {
            List<V030Cid> lista = new List<V030Cid>();
            V030Cid model = null;
            V030CidNG _NG = new V030CidNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Cidade]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V030Cid();
                        model.CodCid = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomCid = leitor["Nome"].ToString();
                        model.IbgCid = Convert.ToInt32(leitor["Codigo_IBGE"].ToString());
                        if (leitor["Capital"].ToString().Equals("0"))
                            model.CapCid = false;
                        else model.CapCid = true;
                        model.CodEst = Convert.ToInt32(leitor["EstadoId"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir no PostgreSQL.
            foreach (V030Cid item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Cidade Convertido com Sucesso.");
        }

        private void btnDepartamento_Click(object sender, EventArgs e)
        {
            List<V070Dep> lista = new List<V070Dep>();
            V070Dep model = null;
            V070DepNG _NG = new V070DepNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Departamento]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V070Dep();
                        model.CodDep = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomDep = leitor["Nome"].ToString();
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir PostgreSQL.
            foreach (V070Dep item in lista)
            {
                if (!_NG.Inserir(model).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Departamento Convertido com Sucesso.");
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            List<V005Usu> lista = new List<V005Usu>();
            V005Usu model = null;
            V005UsuNG _NG = new V005UsuNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Usuario]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V005Usu();
                        model.CodUsu = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomUsu = leitor["Nome"].ToString();
                        model.LogUsu = leitor["Email"].ToString();
                        model.SenUsu = leitor["Senha"].ToString();
                        model.StaUsu = V005UsuStatusEnum.ATIVO;
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            foreach (V005Usu item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Usuário Convertido com Sucesso.");
        }

        private void btnEquipe_Click(object sender, EventArgs e)
        {
            List<V080Eqp> lista = new List<V080Eqp>();
            V080Eqp model = null;
            V080EqpNG _NG = new V080EqpNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Equipe]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V080Eqp();
                        model.CodEqp = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomEqp = leitor["Nome"].ToString();
                        model.LogEqp = Convert.FromBase64String(leitor["Logo"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir no PostgreSQL...
            foreach (V080Eqp item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Equipe Convertido com Sucesso.");
        }

        private void btnPontoVenda_Click(object sender, EventArgs e)
        {
            List<V092Ptv> lista = new List<V092Ptv>();
            V092Ptv model = null;
            V092PtvNG _NG = new V092PtvNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [PontoDeVenda]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V092Ptv();
                        model.CodPtv = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomPtv = leitor["Nome"].ToString();
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir no Postgresql....
            foreach (V092Ptv item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Ponto de Venda Convertido com Sucesso.");
        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
            List<V092Ven> lista = new List<V092Ven>();
            V092Ven model = null;
            V092VenNG _NG = new V092VenNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Vendedor]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V092Ven();
                        model.CodVen = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomVen = leitor["Nome"].ToString();
                        model.SnmVen = leitor["SobreNome"].ToString();
                        model.EmlVen = leitor["Email"].ToString();
                        model.TelVen = leitor["Telefone"].ToString();
                        model.SitVen = Convert.ToBoolean(leitor["Situacao"].ToString());
                        model.ObsVen = leitor["Obs"].ToString();
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir no PostgreSQL....
            foreach (V092Ven item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Vendedor Convertido com Sucesso.");
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            List<V010Emp> lista = new List<V010Emp>();
            V010Emp model = null;
            V010EmpNG _NG = new V010EmpNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Empresa]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V010Emp();
                        model.CodEmp = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomEmp = leitor["Nome"].ToString();
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }
            foreach (V010Emp item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Empresa Convertido com Sucesso.");
        }

        private void btnFilial_Click(object sender, EventArgs e)
        {
            List<V010Fil> lista = new List<V010Fil>();
            V010Fil model = null;
            V010FilNG _NG = new V010FilNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Filial]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V010Fil();
                        model.CodFil = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomFil = leitor["Nome"].ToString();
                        model.FntFil = leitor["NomeFantasia"].ToString();
                        model.IesFil = leitor["InscricaoEstadual"].ToString();
                        model.ImuFil = leitor["InscricaoMunicipal"].ToString();
                        model.DocFil = leitor["CnpjCpf"].ToString();
                        model.EndFil = leitor["Endereco"].ToString();
                        model.CmpFil = leitor["Complemento"].ToString();
                        model.NumFil = leitor["Numero"].ToString();
                        model.BaiFil = leitor["Bairro"].ToString();
                        model.CepFil = leitor["CEP"].ToString();
                        model.EmlFil = leitor["Email"].ToString();
                        model.TelFil = leitor["Telefone"].ToString();
                        model.CelFil = leitor["Celular"].ToString();
                        model.LogFil = Convert.FromBase64String(leitor["Logo"].ToString());
                        model.CodCid = Convert.ToInt32(leitor["CidadeId"].ToString());
                        model.CodEmp = Convert.ToInt32(leitor["EmpresaId"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir PostgreSQL...
            foreach (V010Fil item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da Tabela Filial Convertido com Sucesso.");
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            List<V075Pro> lista = new List<V075Pro>();
            V075Pro model = null;
            V075ProNG _NG = new V075ProNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Produto]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V075Pro();
                        model.CodPro = Convert.ToInt32(leitor["Id"].ToString());
                        model.EanPro = leitor["CodEAN"].ToString();
                        model.NomPro = leitor["Nome"].ToString();
                        model.VlrPro = Convert.ToDouble(leitor["Valor"].ToString());
                        model.CodDep = Convert.ToInt32(leitor["DepartamentoId"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir PostgreSQL....
            foreach (V075Pro item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }
            MessageBox.Show("Dados da TAbela Produto Convertido com Sucesso.");
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            List<V040Cli> lista = new List<V040Cli>();
            V040Cli model = null;
            V040CliNG _NG = new V040CliNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Cliente]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V040Cli();
                        model.CodCli = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomCli = leitor["Nome"].ToString();
                        model.SnmCli = leitor["SobreNome"].ToString();
                        model.EndCli = leitor["Endereco"].ToString();
                        model.NumCli = leitor["Numero"].ToString();
                        model.CmpCli = leitor["Complemento"].ToString();
                        model.BaiCli = leitor["Bairro"].ToString();
                        model.CepCli = leitor["CEP"].ToString();
                        model.TelCli = leitor["Telefone"].ToString();
                        model.CelCli = leitor["Celular"].ToString();
                        model.WhtCli = leitor["Whats"].ToString();
                        model.EmlCli = leitor["Email"].ToString();
                        model.TpPCli = Convert.ToInt32(leitor["FisJur"].ToString());
                        model.DocCli = leitor["CpfIe"].ToString();
                        model.RGIeCli = leitor["RgCnpj"].ToString();
                        if (leitor["Situacao"].ToString().Equals("0"))
                            model.SitCli = false;
                        else model.SitCli = true;
                        model.OBSCli = leitor["Obs"].ToString();
                        model.NascCli = Convert.ToDateTime(leitor["DataNascimento"].ToString());
                        model.TpSCli = leitor["TipoSanguineo"].ToString();
                        model.DiaPag = Convert.ToInt32(leitor["DiaPagamento"].ToString());
                        model.SexCli = (V040CliSexoEnum)Convert.ToInt32(leitor["Sexo"].ToString());
                        model.NomRep = leitor["NomeResponsavel"].ToString();
                        model.RGRep = leitor["RgResponsavel"].ToString();
                        model.CPFRep = leitor["CpfResponsavel"].ToString();
                        if (leitor["MenorIdade"].ToString().Equals("0"))
                            model.MenIda = false;
                        else model.MenIda = true;
                        model.CodPla = Convert.ToInt32(leitor["ClubePlanoId"].ToString());
                        model.CodCid = Convert.ToInt32(leitor["CidadeId"].ToString());
                        model.CodVen = Convert.ToInt32(leitor["VendadeprId"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        model.WhtRep = leitor["WhatsResponsavel"].ToString();
                        model.NomPai = leitor["NomePai"].ToString();
                        model.RGPai = leitor["RgPai"].ToString();
                        model.CPFPai = leitor["CpfPai"].ToString();
                        model.WhtPai = leitor["Whatspai"].ToString();
                        model.NomEsc = leitor["EscolaNome"].ToString();
                        model.AnoEsc = leitor["EscolaAno"].ToString();
                        model.PerEsc = leitor["EscolaPeriodo"].ToString();
                        if (leitor["Goleiro"].ToString().Equals("0"))
                            model.GolCli = false;
                        else model.GolCli = true;
                        model.NomORe = leitor["NomeOutroResponsavel"].ToString();
                        model.RGOre = leitor["RgOutroResponsavel"].ToString();
                        model.CPFOre = leitor["CpfOutroResponsavel"].ToString();
                        model.WhtOre = leitor["WhatsOutroResponsavel"].ToString();
                        model.ResTer = Convert.ToInt32(leitor["ResponsavelTermoAdesao"].ToString());
                        if (leitor["TratamentoMedico"].ToString().Equals("0"))
                            model.TratMed = false;
                        else model.TratMed = true;
                        model.DesTra = leitor["DescTratMed"].ToString();
                        if (leitor["TemAlergia"].ToString().Equals("0"))
                            model.TemAle = false;
                        else model.TemAle = true;
                        model.DesAle = leitor["DescAle"].ToString();
                        model.NomCam = leitor["NomCam"].ToString();
                        model.NumCam = leitor["NumCam"].ToString();
                        model.TamCam = leitor["tamcam"].ToString();
                        model.DtBlo = Convert.ToDateTime(leitor["DataBloqueio"].ToString());
                        model.FotByt = Convert.FromBase64String(leitor["FotoByte"].ToString());
                        model.CrtCli = leitor["Cartao"].ToString();
                        model.CodEqp = Convert.ToInt32(leitor["EquipeId"].ToString());
                        model.EqpPos = leitor["EquipePosicao"].ToString();
                        model.EqpAlt = Convert.ToDecimal(leitor["EquipeAltura"].ToString());
                        model.EqpPes = Convert.ToDecimal(leitor["EquipePeso"].ToString());
                        model.CodPle = Convert.ToInt32(leitor["ClubePlanoEscolinhaId"].ToString());
                        lista.Add(model);
                    }
                    conexao.Close();
                }                
            }
            //Inserir no postgreSQL...
            foreach (V040Cli item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela Cliente Convertido com Sucesso.");
        }

        private void btnDependente_Click(object sender, EventArgs e)
        {
            List<V040Dep> lista = new List<V040Dep>();
            V040Dep model = null;
            V040DepNG _NG = new V040DepNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [ClienteDependente]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V040Dep();
                        model.CodDep = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomDep = leitor["Nome"].ToString();
                        model.SnmDep = leitor["SobreNome"].ToString();
                        model.CodCli = Convert.ToInt32(leitor["ClienteId"].ToString());
                        model.RGDep = leitor["RG"].ToString();
                        model.CPFDep = leitor["CPF"].ToString();
                        model.CrtDep = leitor["Cartao"].ToString();
                        model.FotDep = Convert.FromBase64String(leitor["FotoByte"].ToString());
                        model.NascDep = Convert.ToDateTime(leitor["DataNascimento"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        model.GrpDep = leitor["GrauParentesco"].ToString();
                        model.CodPla = Convert.ToInt32(leitor["ClubePlanoId"].ToString());
                        if (leitor["IsEscolinha"].ToString().Equals("0"))
                            model.EscDep = false;
                        else model.EscDep = true;
                        lista.Add(model);
                    }
                    conexao.Close();
                }
            }

            //Inserir no postgreSQL...
            foreach (V040Dep item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela Dependente Convertido com Sucesso.");

        }

        private void btnTorneio_Click(object sender, EventArgs e)
        {
            List<V180Trn> lista = new List<V180Trn>();
            V180Trn model = null;
            V180TrnNG _NG = new V180TrnNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Torneio]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V180Trn();
                        model.CodTrn = Convert.ToInt32(leitor["Id"].ToString());
                        model.NomTrn = leitor["Nome"].ToString();
                        model.LogTrn = Convert.FromBase64String(leitor["Logo"].ToString());
                        model.DatIni = Convert.ToDateTime(leitor["DataInicio"].ToString());
                        model.DatFim = Convert.ToDateTime(leitor["DataFim"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir postgreSQL...
            foreach (V180Trn item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela Torneio Convertido com Sucesso.");
        }

        private void btnTorneioEquipe_Click(object sender, EventArgs e)
        {
            List<V180Teq> lista = new List<V180Teq>();
            V180Teq model = null;
            V180TeqNG _NG = new V180TeqNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [TorneioEquipe]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V180Teq();
                        model.CodTeq = Convert.ToInt32(leitor["Id"].ToString());
                        model.CodTrn = Convert.ToInt32(leitor["TorneioId"].ToString());
                        model.CodEqp = Convert.ToInt32(leitor["EquipeId"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                    conexao.Close();
                }
            }

            //Inserir postgreSQL...
            foreach (V180Teq item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela Torneio Equipe Convertido com Sucesso.");
        }

        private void btnMovimentacao_Click(object sender, EventArgs e)
        {
            List<V105Mov> lista = new List<V105Mov>();
            V105Mov model = null;
            V105MovNG _NG = new V105MovNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [MovimentacaoEstoque]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V105Mov();
                        model.CodMov = Convert.ToInt32(leitor["Id"].ToString());
                        model.CodPro = Convert.ToInt32(leitor["ProdutoId"].ToString());
                        model.QtdMov = Convert.ToInt32(leitor["Quantidade"].ToString());
                        if (leitor["TipoMovimentacaoEstoque"].ToString().Equals("0"))
                            model.TipMov = "E";
                        if (leitor["TipoMovimentacaoEstoque"].ToString().Equals("1"))
                            model.TipMov = "S";
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Inserir postgreSQL...
            foreach (V105Mov item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela de Movimentação de Estoque Convertido com Sucesso.");
        }

        private void btnMovFinanceiro_Click(object sender, EventArgs e)
        {
            List<V110MovFin> lista = new List<V110MovFin>();
            V110MovFin model = null;
            V110MovFinNG _NG = new V110MovFinNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Movimentacao]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V110MovFin();
                        model.CodMovFin = Convert.ToInt32(leitor["Id"].ToString());
                        model.CodCli = Convert.ToInt32(leitor["ClienteId"].ToString());
                        model.VlrMovFin = Convert.ToDecimal(leitor["Valor"].ToString());
                        model.TipMovFin = leitor["CredDeb"].ToString();
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }

            //Incluir postgreSQL...
            foreach (V110MovFin item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela de MOvimentação Financeira Convertido com Sucesso.");
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            List<V105Cup> lista = new List<V105Cup>();
            V105Cup model = null;
            V105CupNG _NG = new V105CupNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string query = "SELECT * FROM [Venda]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = query;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V105Cup();
                        model.CodCup = Convert.ToInt32(leitor["Id"].ToString());
                        model.CodCli = Convert.ToInt32(leitor["ClienteId"].ToString());
                        model.CodPtv = Convert.ToInt32(leitor["PontoDeVendaId"].ToString());
                        model.TotCup = Convert.ToDecimal(leitor["ValorTotal"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        lista.Add(model);
                    }
                }
                conexao.Close();
            }


            //Inserir no postgreSQL...
            foreach (V105Cup item in lista)
            {
                if (!_NG.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela Venda Convertido com Sucesso.");
        }

        private void btnVendaItem_Click(object sender, EventArgs e)
        {
            List<V105Cit> listaItens = new List<V105Cit>();
            V105Cit model = null;
            V105CitNG _NGItem = new V105CitNG(Vinum.Entidades.Sistema.Sessao.Instancia);

            string qry = "SELECT * FROM [VendaItem]";
            using (SqlConnection conexao = new SqlConnection(SqlServerContext.ConnectionString))
            {
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = qry;
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        model = new V105Cit();
                        model.CodCit = Convert.ToInt32(leitor["Id"].ToString());
                        model.CodPro = Convert.ToInt32(leitor["ProdutoId"].ToString());
                        model.SeqVen = Convert.ToInt32(leitor["SeqVen"].ToString());
                        model.VlrUn = Convert.ToDecimal(leitor["ValorUn"].ToString());
                        model.Qtd = Convert.ToInt32(leitor["Quantidade"].ToString());
                        model.VlrTot = Convert.ToDecimal(leitor["ValorTotal"].ToString());
                        model.DatCad = Convert.ToDateTime(leitor["DataCadastro"].ToString());
                        listaItens.Add(model);
                    }
                }
                conexao.Close();
            }
            //Inserir no postgreSQL...
            foreach (V105Cit item in listaItens)
            {
                if (!_NGItem.Inserir(item).Result)
                    return;
            }

            MessageBox.Show("Dados da Tabela Venda Item Convertido com Sucesso.");
        }

        private void FrmConversorDados_Load(object sender, EventArgs e)
        {

        }
    }
}
