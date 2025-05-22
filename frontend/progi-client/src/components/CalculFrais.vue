<script setup>
import { ref, watch, onMounted } from 'vue';
import axios from 'axios';

const prixBase = ref('');
const typeVehicule = ref('');
const typesVehicules = ref([]);
const listeFrais = ref([]);
const totalFrais = ref(0);
const total = ref(0);
const loading = ref(false);
const error = ref('');


watch([prixBase, typeVehicule], () => {
  if (prixBase.value > 0) {
    calculerFrais();
  } else {
    listeFrais.value = [];
    totalFrais.value = 0;
    total.value = 0;
  }
});

const fetchTypesVehicules = async() => {
  try {
    const response = await axios.get('http://localhost:5005/api/CalculFrais/types-vehicules');
    typesVehicules.value = response.data;
    // on peut set la valeur du type par default à ordinaire
    if (typesVehicules.value.length > 0) {
      typeVehicule.value = typesVehicules.value[0];
    }
  } catch (e) {
    console.error("Erreur de recuperation des types de vehicules :", e);
    error.value = "Erreur lors du chargement des types de véhicules";

  }
};

const calculerFrais = async () => {
  try {
    loading.value = true;
    error.value = '';
    
    const response = await axios.post('http://localhost:5005/api/CalculFrais/calculer', {
      prixBase: parseFloat(prixBase.value),
      typeVehicule: typeVehicule.value
    });
    
    listeFrais.value = response.data.detailsFrais;
    totalFrais.value = response.data.totalFrais;
    total.value = response.data.total;
    loading.value = false;

  } catch(e) {
    console.error('Erreur lors du calcul des frais:', e);
    error.value = "Erreur dans le calcul des frais";
  }
};

const currencyFormat = (montant) => {
  return new Intl.NumberFormat('fr-CA', {
    style: 'currency',
    currency: 'CAD'
  }).format(montant);
};

onMounted(() => {
  fetchTypesVehicules();
});

</script>

<template>
  <div class="max-w-2xl mx-auto p-5 font-sans bg-white text-black">
    <h1 class="text-center text-2xl font-medium text-black-700 mb-6">Calculateur d'Enchères de Véhicule</h1>
    
    <div class="mb-5">
      <label for="prixBase" class="block mb-2 font-semibold text-black">Prix du véhicule :</label>
      <input 
        type="number" 
        id="prixBase" 
        v-model="prixBase" 
        min="1"
        step="0.01"
        placeholder="Entrez le prix du vehicule"
        class="w-full p-2 border border-gray-300 rounded text-base text-black"
      />
    </div>
    
    <div class="mb-5">
      <label class="block mb-2 font-semibold text-black">Type du véhicule :</label>
      <div class="flex gap-5">
        <label v-for="type in typesVehicules" :key="type" class="flex items-center gap-2 font-normal text-black">
          <input type="radio" v-model="typeVehicule" :value="type" />
          {{ type }}
        </label>
      </div>
    </div>
    
    <div v-if="loading" class="text-center py-5 italic text-gray-500">
      Calcul en cours...
    </div>
    
    <div v-else-if="error" class="text-center p-3 border border-red-500 rounded text-red-600 mt-5">
      {{ error }}
    </div>
    
    <div v-else-if="listeFrais.length > 0" class="mt-8 border border-gray-300 rounded p-5 bg-gray-50">
      <h2 class="mt-0 text-gray-700 text-xl mb-4">Détails des frais</h2>
      
      <div class="flex justify-between py-2 border-b border-gray-200">
        <span class="text-black">Prix de base:</span>
        <span class="text-black-700">{{ currencyFormat(prixBase) }}</span>
      </div>
      
      <div class="py-1">
        <div v-for="(item, index) in listeFrais" :key="index" class="flex justify-between py-2 border-b border-gray-200">
          <span>{{ item.description }}:</span>
          <span class="text-black-700">{{ currencyFormat(item.montant) }}</span>
        </div>
      </div>
      
      <div class="flex justify-between py-2 border-b border-gray-200 font-semibold mt-3">
        <span>Total des frais:</span>
        <span class="text-black-700">{{ currencyFormat(totalFrais) }}</span>
      </div>
      
      <div class="flex justify-between py-2 font-bold mt-3 text-lg">
        <span class="text-black">Prix total:</span>
        <span class="text-black-700">{{ currencyFormat(total) }}</span>
      </div>
    </div>
  </div>
</template>