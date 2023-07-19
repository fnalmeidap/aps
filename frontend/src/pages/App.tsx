import { BrowserRouter } from "react-router-dom";
import AppRoutes from "../routes/index";
import { CssBaseline, ThemeProvider, createTheme } from '@mui/material';
import * as colors from '@mui/material/colors';

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
    primary: colors.green
  },
});

function App() {
  return (
    <ThemeProvider theme={darkTheme}>
      <CssBaseline/>
      <BrowserRouter>
        <AppRoutes />
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;
