using System;

namespace FluentHtmlBuilder.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criando o html
            var html = new HtmlElement("html").WithAttribute("lang", "pt-br");

            //Criando o head
            var head = new HtmlElement("head")
                .WithChild(new HtmlElement("meta").WithAttribute("charset", "utf-8"))
                .WithChild(new HtmlElement("meta")
                            .WithAttribute("name", "viewport")
                            .WithAttribute("content", "width=device-width, initial-scale=1, shrink-to-fit=no"))
                .WithChild(new HtmlElement("link")
                    .WithAttribute("rel", "stylesheet")
                    .WithAttribute("href", "https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css")
                )
                .WithChild(new HtmlElement("title")
                    .WithText("Exemplo de criação de html")
                );

            //Criando o body
            var body = new HtmlElement("body")
                .WithAttribute("style", "margins: 1em;");

            //Criando uma div para o conetúdo
            var content = new HtmlElement("div")
               .WithAttribute("class", "container-fluid");

            //Criando o form
            var form = new HtmlElement("form")
                .WithAttribute("action", "#")
                .WithAttribute("method", "get");

            //Criando o Campo Email
            var email = new HtmlElement("div").WithAttribute("class", "form-group")
                .WithChild(new HtmlElement("Label")
                            .WithAttribute("for", "email")
                            .WithText("Email address")
                            )
                .WithChild(new HtmlElement("input", true)
                            .WithAttribute("class", "form-control")
                            .WithAttribute("id", "email")
                            .WithAttribute("name", "email")
                            .WithAttribute("type", "email")
                            .WithAttribute("aria-describedby", "emailHelp")
                            .WithAttribute("placeholder", "Email")
                            )
                .WithChild(new HtmlElement("small")
                            .WithAttribute("id", "emailHelp")
                            .WithAttribute("class", "form-text text-muted")
                            .WithText("We'll never share your email with anyone else"));


            //Criando o Campo Password
            var password = new HtmlElement("div").WithAttribute("class", "form-group")
                .WithChild(new HtmlElement("Label")
                            .WithAttribute("for", "password")
                            .WithText("Password"))
                .WithChild(new HtmlElement("input", true)
                            .WithAttribute("class", "form-control")
                            .WithAttribute("id", "password")
                            .WithAttribute("name", "password")
                            .WithAttribute("type", "password")
                            .WithAttribute("placeholder", "Password"));


            //Criando o botão
            var button = new HtmlElement("button ")
                .WithAttribute("type", "submit")
                .WithAttribute("class", "btn btn-primary")
                .WithText("Submit");

            //Criando Tag de Scripts

            var scriptJquery = new HtmlElement("script")
                .WithAttribute("src", "https://code.jquery.com/jquery-3.2.1.slim.min.js")
                .WithAttribute("integrity", "sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN")
                .WithAttribute("crossorigin", "anonymous");
            var scriptPopper = new HtmlElement("script")
                .WithAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js")
                .WithAttribute("integrity", "sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q")
                .WithAttribute("crossorigin", "anonymous");
            var scriptBootstrap = new HtmlElement("script")
                .WithAttribute("src", "https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js")
                .WithAttribute("integrity", "sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl")
                .WithAttribute("crossorigin", "anonymous");
            
            //Adicionando itens ao form
            form.WithChild(email).WithChild(password).WithChild(button);

            //Adicionando itens ao content
            content.WithChild(form).WithChild(scriptJquery).WithChild(scriptPopper).WithChild(scriptBootstrap);

            //Adicionando content ao body
            body.WithChild(content);

            //Adicionando Head e Body ao Html
            html.WithChild(head).WithChild(body);

            //Renderizando
            Console.WriteLine(html.Render(RenderOptions.WithFormat));
            Console.ReadKey();
        }
    }
}
