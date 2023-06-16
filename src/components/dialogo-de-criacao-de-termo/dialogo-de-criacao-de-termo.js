import { inject } from 'aurelia-framework';
import { TermoApi } from "../../termo-api";

@inject(TermoApi)
export class DialogoDeCriacaoDeTermo {
  constructor(termoApi) {
    this.termoApi = termoApi;
  }

  abrirDialogo() {
    document.getElementById("dialogoDeCriacaoDeTermo").style.display = 'block';
  }

  fecharDialogo() {
    this.limparVariaveis();
    document.getElementById("dialogoDeCriacaoDeTermo").style.display = 'none';
  }

  adicionarTermo() {
    const termo = {
      "termo": this.termo,
      "descricao": this.descricao,
      "link": this.link
    }

    this.termoApi.salvarTermo(termo).then(
      resposta => {
        console.log(resposta);
        this.fecharDialogo();
      }
    );
  }

  limparVariaveis() {
    this.termo = "";
    this.descricao = "";
    this.link = "";
  }
}