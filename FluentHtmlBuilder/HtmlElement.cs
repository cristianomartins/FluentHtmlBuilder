using System.Collections.Generic;
using System.Text;

namespace FluentHtmlBuilder
{
    public enum RenderOptions
    {
        WithFormat,
        None
    }

    public class HtmlElement
    {
        public string Tag { get; }

        private bool _selfClose;
        private StringBuilder _builder;
        private IList<HtmlElement> _listChilds;
        private IDictionary<string, string> _listAttibutes;
        private string _text;


        public HtmlElement(string tag)
            : this(tag, false)
        {

        }

        public HtmlElement(string tag, bool selfClose)
        {
            Tag = tag;
            _selfClose = selfClose;
            _builder = new StringBuilder();
            _listChilds = new List<HtmlElement>();
            _listAttibutes = new Dictionary<string, string>();
        }

        /// <summary>
        /// Renderiza o HTML
        /// </summary>
        /// <param name="renderOptions"></param>
        /// <returns>Html</returns>
        public string Render(RenderOptions renderOptions = RenderOptions.None)
        {
            RenderTag();

            if (_selfClose) return _builder.ToString();

            _builder.Append(_text);

            foreach (var child in _listChilds)
                _builder.Append(child.Render());

            _builder.Append("</");
            _builder.Append(Tag);
            _builder.Append(">");

            return renderOptions == RenderOptions.None ? _builder.ToString()
                : System.Xml.Linq.XElement.Parse(_builder.ToString()).ToString();
        }

        private string RenderTag()
        {
            _builder.Append('<');
            _builder.Append(Tag);

            foreach (var attr in _listAttibutes)
                _builder.Append($" {attr.Key}=\"{attr.Value}\"");

            _builder.Append(_selfClose ? "/>" : ">");
            return _builder.ToString();
        }

        /// <summary>
        /// Insere elementos como filhos do elemento atual
        /// </summary>
        /// <param name="htmlElement"></param>
        /// <returns></returns>
        public HtmlElement WithChild(HtmlElement htmlElement)
        {
            _listChilds.Add(htmlElement);
            return this;
        }

        /// <summary>
        /// Insere um atributo na TAG atual 
        /// </summary>
        /// <param name="name">Nome do atributo</param>
        /// <param name="value">Valor do atributo</param>
        /// <returns></returns>
        public HtmlElement WithAttribute(string name, string value)
        {
            try
            {
                _listAttibutes.Add(name, value);
                return this;
            }
            catch (System.ArgumentException)
            {
                throw new System.ArgumentException($"Já existe um atributo chamado {name}");
            }
        }

        /// <summary>
        /// Adiciona um texto na TAG Ex: <div>aqui será inserido o conteúdo</div>
        /// </summary>
        /// <param name="tex">Texto que deve ser inserido</param>
        /// <returns></returns>
        public HtmlElement WithText(string text)
        {
            _text = text;
            return this;
        }
    }
}
