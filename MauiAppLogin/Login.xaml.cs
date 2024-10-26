namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

		try
		{

			List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
			{

				new DadosUsuario()
				{
					Usuario = "jose",
					Senha = "123"
				},

                new DadosUsuario()
                {
                    Usuario = "maria",
                    Senha = "321"
                }
            };

			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

            //LINQ
            bool encontrou = lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha));

            if (encontrou)
            {
                SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

                App.Current.MainPage = new Protegido();

            }
            else
            {
                throw new Exception("Usuário ou senha incorretos.");
            }


        }
        catch (Exception ex)
		{
			DisplayAlert("ops", ex.Message, "Fechar");
		}

    }
}