<template>
  <transition name="modal">
    <div class="modal-mask">
      <div class="modal-wrapper">
        <div class="modal-container">
          <div class="modal-header">
            <slot name="header">
                <h3>{{componentType}} REGISTRATION</h3>
            </slot>
          </div>

          <div class="modal-body">
              <form-product :product="this.objAlter" @changeProduct="this.changeProduct" v-if="componentType == 'PRODUCT'" />
          </div>

          <div class="modal-footer">
            <div class="content-center">
              <md-button class="md-raised md-primary" @click="() => this.aqui()">Save</md-button>
              <md-button class="md-accent" @click="() => this.$emit('close')">Cancel</md-button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
import FormProduct from './FormProduct'

export default {
  name: "Modal",
  components: {
      FormProduct
  },
  props: {
      componentType: String,
      obj: Object
  },
  beforeMount() {
      this.objAlter = this.obj
      // eslint-disable-next-line no-debugger
      debugger;
  },
  data: () =>({
      objAlter: null
  }),
  methods: {
    changeProduct(obj){
        this.objAlter = obj;
    },
    aqui(){
        // eslint-disable-next-line no-debugger
        debugger;
    }
  }
};
</script>

<style scoped>
.modal-mask {
  position: fixed;
  z-index: 10;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}

.modal-container {
  width: 300px;
  margin: 0px auto;
  padding: 20px 30px;
  background-color: #fff;
  border-radius: 2px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
  transition: all 0.3s ease;
  font-family: Helvetica, Arial, sans-serif;
  width: 50%;
}

.modal-header h3 {
  margin-top: 0;
  color: #42b983;
}

.modal-body {
  margin: 20px 0;
}

.modal-default-button {
  float: right;
}

/*
 * The following styles are auto-applied to elements with
 * transition="modal" when their visibility is toggled
 * by Vue.js.
 *
 * You can easily play with the modal transition by editing
 * these styles.
 */

.modal-enter {
  opacity: 0;
}

.modal-leave-active {
  opacity: 0;
}

.modal-enter .modal-container,
.modal-leave-active .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
</style>