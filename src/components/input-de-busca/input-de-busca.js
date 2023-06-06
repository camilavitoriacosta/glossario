import { bindable, inject } from 'aurelia-framework';
import { TermoApi } from '../../termo-api';


@inject(TermoApi)
export class InputDeBusca {
  @bindable controladorListaTermos;

  constructor(termoApi) {
    this.termoApi = termoApi;
  }

  attached() {
    this.termoApi.obterTermos().then(resposta => resposta.json()).then(resposta => {
      this.termos = resposta;
    });
  }

  buscar() {
    this.controladorListaTermos.termos = this.termos.filter(termoAtual =>
      termoAtual.termo.toUpperCase().includes(this.termoBuscado.toUpperCase())
    )
  }
}