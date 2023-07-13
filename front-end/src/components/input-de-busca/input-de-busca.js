import { bindable } from 'aurelia-framework';

export class InputDeBusca {
  @bindable controladorListaTermos;
  @bindable termos;
  @bindable termosExibicao;

  buscar() {
    this.termosExibicao = this.termos.filter(termoAtual =>
      termoAtual.termo.toUpperCase().includes(this.termoBuscado.toUpperCase())
    )
  }

  limparBusca() {
    this.termoBuscado = '';
    this.termosExibicao = this.termos;
  }
}