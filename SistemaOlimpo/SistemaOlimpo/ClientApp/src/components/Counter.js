import React, { useState } from 'react';
import { Button } from 'reactstrap';

export function Counter() {
  const [counter, setCounter] = useState(0);

  function incrementCounter() {
    setCounter(p => p+1)
  }

    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p aria-live="polite">Current count: <strong>{counter}</strong></p>

        <Button color='primary' onClick={incrementCounter}>Increment</Button>
      </div>
    );
}
