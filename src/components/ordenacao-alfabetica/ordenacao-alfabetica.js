import { bindable } from 'aurelia-framework';

const _ = require("lodash");

export class OrdenacaoAlfabetica {
  @bindable callbackOrdenarListagemTermos;
  @bindable controladorListaTermos;

  attached() {
    this.termos = this.controladorListaTermos.termos;
  }

  tiposDeOrdenacao = [
    //this.termos = _.orderBy(this.termos, ['termo'], ['asc']) 
    //this.termos = _.orderBy(this.termos, ['termo'], ['desc']) 
    { id: 0, label: "A - Z", ordenar: (termos) => { this.controladorListaTermos.termos = _.orderBy(termos, ['termo'], ['asc']) } },
    { id: 1, label: "Z - A", ordenar: (termos) => { this.controladorListaTermos.termos = _.orderBy(termos, ['termo'], ['desc']) } }
  ]

  tipoOrdenacaoSelecionado = this.tiposDeOrdenacao[0];

  ordenarTermos() {
    this.termos = this.controladorListaTermos.termos;
    this.tipoOrdenacaoSelecionado.ordenar(this.termos)
  }
}