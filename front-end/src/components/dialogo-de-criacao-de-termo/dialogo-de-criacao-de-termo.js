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

  @computedFrom('titulo', 'descricao', 'link')
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
    this.titulo = termo.termo.titulo;
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
      "titulo": this.titulo,
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
      "id": this.idTermoParaEditar,
      "titulo": this.titulo,
      "descricao": this.descricao,
      "link": this.link
    }

    this.termoApi.editarTermo(termo).then(
      () => {
        this.fecharDialogo();
        this.callbackDeAdicaoDeTermo();
      }
    );
  }

  validarCamposFormulario() {
    const termoValido = this.validarCampoTexto(this.titulo, 'alerta-termo');
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
    this.titulo = '';
    this.descricao = '';
    this.link = '';
    this.idTermoParaEditar = -1;
  }
}