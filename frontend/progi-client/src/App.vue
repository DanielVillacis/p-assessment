<script setup>
import CalculFrais from './components/CalculFrais.vue'
</script>

<template>
  <div class="app-wrapper">
    <main>
      <CalculFrais />
    </main>
  </div>
</template>

<style scoped>
.app-wrapper {
  min-height: 100vh;
  width: 100%;
  background-color: white;
}

header {
  line-height: 1.5;
  max-height: 100vh;
  margin-bottom: 2rem;
}

.wrapper {
  width: 100%;
  text-align: center;
}

h1 {
  font-size: 2rem;
  font-weight: 500;
  color: #2c3e50;
}

main {
  max-width: 800px;
  margin: 0 auto;
  padding: 0 1rem;
}
</style>