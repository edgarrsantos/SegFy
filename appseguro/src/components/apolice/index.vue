<template>
  <div class="p-4">
    <div class="card">
      <div class="card-header">Apólices</div>
      <div class="card-body">
        <button class="btn btn-info" @click="openModal()">Nova apólice</button>

        <table class="table table-striped table-light">
          <thead>
            <tr>
              <th scope="col"></th>
              <th scope="col">#</th>
              <th scope="col">CpfCnpj</th>
              <th scope="col">Placa</th>
              <th scope="col">Valor Prêmio</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(apolice, idx) in listaApolices" :key="apolice.numApolice">
              <td>
                <button class="btn btn-sm btn-secondary mr-1" @click="openModal(apolice)">Editar</button>
                <button
                  class="btn btn-sm btn-danger"
                  @click.prevent="deleteApolice(apolice.numApolice, idx)"
                >Excluir</button>
              </td>
              <td>{{apolice.numApolice}}</td>
              <td>{{apolice.cpfcnpj | cpfcnpj}}</td>
              <td>{{apolice.placa}}</td>
              <td>{{apolice.valorPremio}}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <b-modal ref="modalApolice" :title="tituloModal">
      <form>
        <input type="hidden" v-model="apolice.numApolice">

        <div class="form-group">
          <label for="txtCpfCnpj">CPF/CNPJ</label>
          <mask-input
            type="text"
            class="form-control"
            id="txtCpfCnpj"
            v-model="apolice.cpfcnpj" 
            :mask="['###.###.###-##', '##.###.###/####-##']"
          ></mask-input>
        </div>
        <div class="form-group">
          <label for="txtPlaca">Placa</label>
          <mask-input
            type="text"
            class="form-control"
            id="txtPlaca"
            v-model="apolice.placa"
            :mask="['SSS#X##']" 
          ></mask-input>
        </div>
        <div class="form-group">
          <label for="txtValor">Valor</label>
          <input type="number" class="form-control" id="txtValor" v-model="apolice.valorPremio">
        </div>
      </form>

      <div slot="modal-footer">
        <div class="content-justify-end">
          <b-button class="btn btn-secondary mr-1" @click="hideModal">Cancelar</b-button>
          <b-button class="btn btn-info" @click="saveApolice">Salvar</b-button>
        </div>
      </div>
    </b-modal>
  </div>
</template>

<style>
</style>

<script>
import { TheMask } from "vue-the-mask";
export default {
  name: "apolice",
  components: {
    "mask-input": TheMask
  },
  data() {
    return {
      listaApolices: [],
      tituloModal: "Nova apólice",
      apolice: {
        numApolice: 0,
        placa: null,
        valorPremio: 0,
        cpfcnpj: null
      }
    };
  },

  mounted() {
    this.getApolices();
  },

  filters: {
    cpfcnpj(valor) {
      if (valor.length === 11)
        return valor.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, "$1.$2.$3-$4");
      else
        return valor.replace(
          /(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/g,
          "$1.$2.$3/$4-$5"
        );
    }
  },

  methods: {
    hideModal() {
      this.$refs["modalApolice"].hide();
    },

    openModal(apolice) {
      this.apolice = {
        numApolice: 0,
        placa: null,
        valorPremio: 0,
        cpfcnpj: null
      };

      if (apolice) {
        this.tituloModal = "Editar Apólice";
        this.apolice = apolice;
      }

      this.$refs["modalApolice"].show();
    },

    saveApolice() {
      if (this.apolice.numApolice > 0) {
        window.http
          .put("/apolice/" + this.apolice.numApolice, this.apolice)
          .then(ret => {
            if (ret.status == 200) {
              if (!ret.data.erro) {
                var idx = this.listaApolices.findIndex(
                  obj => obj.numApolice == this.apolice.numApolice
                );
                this.listaApolices[idx] = this.apolice;
                this.hideModal();
              } else {
                alert(ret.data.mensagem);
              }
            } else alert("Ocorreu um erro inesperado.");
          });
      } else {
        window.http.post("/apolice", this.apolice).then(ret => {
          if (ret.status == 200) {
            if (!ret.data.erro) {
              this.listaApolices.push(ret.data.object);
              this.hideModal();
            } else {
              alert(ret.data.mensagem);
            }
          } else alert("Ocorreu um erro inesperado.");
        });
      }
    },

    getApolices() {
      window.http.get("/apolice").then(ret => {
        if (ret.status == 200) {
          if (!ret.data.erro) {
            this.listaApolices = ret.data.object;
          } else {
            alert(ret.data.mensagem);
          }
        } else alert("Ocorreu um erro inesperado.");
      });
    },

    deleteApolice(id, idx) {
      window.http.delete("/apolice/" + id).then(ret => {
        if (ret.status == 200) {
          if (!ret.data.erro) {
            this.listaApolices.splice(idx, 1);
          } else {
            alert(ret.data.mensagem);
          }
        } else alert("Ocorreu um erro inesperado.");
      });
    }
  }
};
</script>
