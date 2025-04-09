<template>
    <div class="p-4">
        <div class="mb-4 flex gap-4">
            <input v-model="filter.baseCurrency"
                class="input"
                placeholder="Base Currency (e.g. USD)" />
            <input v-model="filter.currency"
                class="input"
                placeholder="Currency (e.g. EUR)" />
            <input type="date"
                v-model="filter.date"
                class="input" />
        </div>

        <table class="w-full border border-gray-200 rounded-lg">
            <thead>
                <tr class="bg-gray-100 text-left">
                    <th class="p-2">Date</th>
                    <th class="p-2">Base</th>
                    <th class="p-2">Currency</th>
                    <th class="p-2">Amount</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="rate in filteredRates"
                    :key="`${rate.date}-${rate.baseCurrency}-${rate.currency}`">
                    <td class="p-2">{{ rate.date }}</td>
                    <td class="p-2">{{ rate.baseCurrency }}</td>
                    <td class="p-2">{{ rate.currency }}</td>
                    <td class="p-2">{{ rate.amount }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted } from 'vue';
import { getExchangeRates, ExchangeRate } from '@/services/exchangeRateService';

const rates = ref<ExchangeRate[]>([]);
const filter = ref({ baseCurrency: '', currency: '', date: '' });

const filteredRates = computed(() =>
    rates.value.filter(rate =>
        (!filter.value.baseCurrency || rate.baseCurrency.includes(filter.value.baseCurrency.toUpperCase())) &&
        (!filter.value.currency || rate.currency.includes(filter.value.currency.toUpperCase())) &&
        (!filter.value.date || rate.date === filter.value.date)
    )
);

onMounted(async () => {
    rates.value = await getExchangeRates();
});
</script>

<style scoped>
.input {
    border: 1px solid #ddd;
    padding: 0.5rem;
    border-radius: 0.375rem;
    width: 200px;
}
</style>
