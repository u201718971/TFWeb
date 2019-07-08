<template>
  <v-flex>     

<v-dialog v-model="dialog" max-width="500px">
          <v-card>
            <v-card-title>
              <span class="headline"> Detalles producto</span>
            </v-card-title>
            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="nombre" label="nombre" readonly></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="tipoproducto" label="tipoproducto" readonly></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="generoid" label="generoid" readonly ></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="talla" label="talla" readonly ></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="precio" label="precio" readonly ></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="stock" label="stock" readonly ></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm6 d-flex>
                  <v-select v-model= "box"
                   :items="Cantidad"
                     label="Cantidad de productos"
                   ></v-select>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>
            <v-card-actions>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click="Add()">AGREGAR AL CARRITO</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>

  <v-layout align-start row wrap>
      <v-data-table :headers="headers" :items="productos" :search="search" class="elevation-1" >
        <template v-slot:items = "props" >
          <td class="justify-center layout px-0">
            <v-btn big class="mr-0" @click="detalles(props.item)">detalles</v-btn> 

          </td>
          <td hidden = true>{{ props.item.id }}</td>
          <td>{{ props.item.nombre }}</td>
          <td>{{ props.item.precio }}</td>
          <td>{{ props.item.stock }}</td>
          <td hidden> {{ props.item.talla }}</td>
          <td hidden> {{ props.item.tipoproducto }}</td>
          <td hidden> {{ props.item.generoid }}</td>



       </template>
        <template slot="no-data">
          <v-btn class="black yellow--text" large @click="listar()">No hay productos disponibles</v-btn>
        </template>
      </v-data-table>
        <br><br><br><br><br><br><br><br><br>

        <v-layout justify-space-around>
        <span class="group pa-2">
          <v-icon x-large >shopping_cart</v-icon>

        </span>
  
      </v-layout>

  </v-layout>
  </v-flex>

</template>
<script>
import axios from "axios";


export default {
  data() {
    return {
      productos: [],
      box: [],
      dialog: false,

      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombre", value: "nombre", sortable: false },
        { text: "Precio", value: "precio", sortable: false },
        { text: "Stock", value: "stock", sortable: false },
        {text: "Generoid", value: "generoid", sortable: false},       
        {text: "Talla", value: "talla", sortable: false},       
        {text: "TipoProducto", value: "tipoproducto", sortable: false}
      ],

      Cantidad:[1,2,3,4,5,6,7,8,9,10],
      search: "",


      //Model
      id: "",
      nombre: "",
      precio: "",
      stock: "",
      tipoproducto: "",
      generoid: "",
      talla: "",  
      ventaid:1,
      box: ""
      };
  },
  computed: { },

  watch: {},

  created() {
    this.listar();
  },

  methods: {
    listar() {
      let me = this;

      axios
        .get("api/productoes")
        .then(function(response) {
          //console.log(response);
          me.productos = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    


    detalles(item) {
      this.dialog = true;
      this.nombre = item.nombre;
      this.tipoproducto = item.tipoproducto;
      this.generoid = item.generoid;
      this.talla = item.talla;
      this.stock = item.stock;
      this.precio = item.precio;
    },

      close() {
      this.dialog = false;
    },
    
    limpiar() {
      this.id = "";
      this.nombres = "";
      this.direccion = "";
    },
    Add()
    {

    
      let me = this;
        axios.
        post("api/ListaVentas", {
          ventaid: me.ventaid,
          productoid: me.productoid,
          cantidad: me.box,
          total: me.box*me.precio
        })     
            .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      
       
    }
      
  }
  
};
</script>