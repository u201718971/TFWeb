<template>
  <v-container>
    <v-layout
      text-xs-center
      wrap
    >
      <v-flex xs12>
        <v-img
          :src="require('../assets/LogoAF.jpg')"
          class="my-3"
          contain
          height="430"
        ></v-img>
      </v-flex>

      <v-flex
        mb-5
        xs12
      >
        <h2 class="headline font-weight-bold mb-3">¡BIENVENIDO A ATHLETIC STUFF!</h2>

        <v-layout justify-center>
        </v-layout>
      </v-flex>

      <v-btn block class="yellow dark--text" :to="{name : 'productos'}"> EMPEZAR A COMPRAR YA</v-btn>


    </v-layout>
  </v-container>
</template>

<script>

</script>


