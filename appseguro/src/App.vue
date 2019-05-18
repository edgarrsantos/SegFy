<template>
  <div id="app">
    <b-navbar toggleable="lg" class="navbar-light bg-light">
    <b-navbar-brand href="#" to="/home">
      <img src="@/assets/img/logo_segfy.png" alt="">
    </b-navbar-brand>

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <b-nav-item href="#" to="/home">Home</b-nav-item>
        <b-nav-item href="#" to="/apolices">Apólices</b-nav-item>
      </b-navbar-nav>

      <b-navbar-nav class="ml-auto">
        <b-nav-item-dropdown right>
          <template slot="button-content"><em>Administrador</em></template>
          <b-dropdown-item href="#">Alterar senha</b-dropdown-item>
          <b-dropdown-item href="#">Sair</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>


      <router-view></router-view>

      
  </div>
</template>

<script>

export default {
  name: 'app',

  data (){
    return {
        
    }
  },

  components: {
    
  },

  methods: {

  }
}
</script>

<style>

</style>
