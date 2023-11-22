using System.Text.Json.Serialization;

namespace RefitApi.Models
{
    using System;
    using System.Collections.Generic;

    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Globalization;

    public partial class TiposUnidade
    {
        [JsonPropertyName("tipos_unidade")]
        public List<TiposUnidadeElement> TiposUnidadeTiposUnidade { get; set; }
    }

    public partial class TiposUnidadeElement
    {
        [JsonPropertyName("codigo_tipo_unidade")]
        public long CodigoTipoUnidade { get; set; }

        [JsonPropertyName("descricao_tipo_unidade")]
        public string DescricaoTipoUnidade { get; set; }
    }
}
