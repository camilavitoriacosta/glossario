import { bindable, computedFrom, inject } from 'aurelia-framework';
import { TermoApi } from "../../termo-api";
const _ = require("lodash");

@inject(TermoApi)
export class DialogoDeCriacaoDeTermo {
  @bindable callbackDeAdicaoDeTermo = () => { };


  @computedFrom('idTermoParaEditar')
  get ehEdicao() {
    return this.idTermoParaEditar >= 0;
  }

  @computedFrom('descricao')
  get contadorCampoDescricao() {
    return this.descricao ? this.descricao.length : 0;
  }

  @computedFrom('termo', 'descricao', 'link')
  get habilitarBotao() {
    return this.validarCamposFormulario();
  }

  constructor(termoApi) {
    this.termoApi = termoApi;
    this.idTermoParaEditar = -1;
  }

  abrirDialogo() {
    document.getElementById("dialogoDeCriacaoDeTermo").style.display = 'block';
    document.querySelectorAll('.alerta').forEach(alerta => {
      alerta.textContent = '';
      alerta.classList.remove('alerta-erro');
    });
  }

  abrirDialogoEdicao(termo) {
    this.termo = termo.termo.termo;
    this.descricao = termo.termo.descricao;
    this.link = termo.termo.link;
    this.idTermoParaEditar = termo.termo.id;
    this.abrirDialogo();
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
      () => {
        this.fecharDialogo();
        this.callbackDeAdicaoDeTermo();
      }
    );
  }

  editarTermo() {
    const termo = {
      "termo": this.termo,
      "descricao": this.descricao,
      "link": this.link
    }

    this.termoApi.editarTermo(this.idTermoParaEditar, termo).then(
      () => {
        this.fecharDialogo();
        this.callbackDeAdicaoDeTermo();
      }
    );
  }

  validarCamposFormulario() {
    const termoValido = this.validarCampoTexto(this.termo, 'alerta-termo');
    const descricaoValida = this.validarCampoTexto(this.descricao, 'alerta-descricao');
    const linkValido = this.validarCampoTexto(this.link, 'alerta-link');
    return termoValido && descricaoValida && linkValido;
  }

  validarCampoTexto(campo, idAlerta) {
    let valido = false;
    valido = Boolean(campo) && campo.trim() != '';
    const elemento = document.getElementById(idAlerta);
    if (elemento) {
      if (!valido) {
        elemento.classList.add('alerta-erro');
        elemento.textContent = 'Esse campo é obrigatório.';
      }
      else {
        elemento.classList.remove('alerta-erro');
        elemento.textContent = '';
      }
    }

    return valido;
  }

  limparVariaveis() {
    this.termo = '';
    this.descricao = '';
    this.link = '';
    this.idTermoParaEditar = -1;
  }
}