import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Risk } from './components/Risk';
import { Counter } from './components/Counter';
import { FetchData } from './components/FetchData';

export default function App() {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route path='/counter' component={Counter} />
      <Route path='/risk' component={Risk} />
      <Route path='/fetch-data' component={FetchData} />
    </Layout>
  );
}
