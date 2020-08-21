import React from 'react';
import { render } from '@testing-library/react';
import App from './App';

test('renders Projects List here', () => {
  const { getByText } = render(<App />);
  const element = getByText(/Projects List Here/i);
  expect(element).toBeInTheDocument();
});
